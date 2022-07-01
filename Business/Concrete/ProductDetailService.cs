using AutoMapper;
using Business.Abstract;
using Core.Concrete;
using Core.ExceptionHandler;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.ProductDetailRequestDto;
using Entities.Dto.ResponseDto.ProductDetailResponseDto;
using Entities.Enums;
using LinqKit;

namespace Business.Concrete
{
    public class ProductDetailService : BaseService<ProductDetail>, IProductDetailService
    {
        private readonly IProductDetailDal productDetailDal;
        private readonly IProductDal productDal;
        private readonly IMerchantDal merchantDal;
        private readonly IMapper mapper;
        public ProductDetailService(IProductDetailDal productDetailDal, 
                                    IProductDal productDal, 
                                    IMerchantDal merchantDal, 
                                    IMapper mapper)
        {
            this.productDetailDal = productDetailDal;
            this.productDal = productDal;
            this.merchantDal = merchantDal;
            this.mapper = mapper;
        }

        public void AddProductDetail(AddProductDetailRequest addProductDetail)
        {
            var productDetail = mapper.Map<ProductDetail>(addProductDetail);
            productDetail.Product = productDal.GetById(addProductDetail.ProductId);
            productDetail.Merchant = merchantDal.GetById(addProductDetail.MerchantId);
            productDetailDal.Insert(productDetail);
        }

        public List<GetProductDetailResponse> GetProductsDetail(GetProductDetailRequest getProductDetail)
        {
            if(getProductDetail.ProductId == Guid.Empty)
            {
                throw new AppException("ProductDetail.ChooseProductToGetDetails", ExceptionTypes.BadRequest.GetValue());
            }

            var predicate = PredicateBuilder.New<ProductDetail>()
                .And(x => x.Product.ProductId == getProductDetail.ProductId)
                .And(x => x.Merchant.MerchantId == getProductDetail.MerchantId);

            var productdetails = productDetailDal.GetMany(predicate, x => x.Merchant);

            var productDetailResponse = new List<GetProductDetailResponse>();

            foreach (var productDetail in productdetails)
            {
                productDetailResponse.Add(new GetProductDetailResponse()
                {
                    Color = productDetail.Color,
                    Count = productDetail.Count,
                    Detail = productDetail.Detail,
                    Price = productDetail.Price,
                    Size = productDetail.Size,
                    MerchantName = productDetail.Merchant.MerchantName,
                    ClickCount = productDetail.ClickCount,
                    PurchaseCount = productDetail.PurchaseCount
                });
            }

            return productDetailResponse;

        }

        public void UpdateProductDetail(UpdateProductDetailRequest updateProductDetail)
        {
            var predicate = PredicateBuilder.New<ProductDetail>()
                .And(x => x.Product.ProductId == updateProductDetail.ProductId)
                .And(x => x.Merchant.MerchantId == updateProductDetail.MerchantId);

            var productDetail = productDetailDal.Get(predicate, x => x.Merchant);

            mapper.Map(updateProductDetail, productDetail);

            productDetailDal.Update(productDetail);
        }

        public void UpdateClickedCount(UpdateProductDetailClickCountRequest updateProductDetail)
        {
            var productDetail = productDetailDal.GetById(updateProductDetail.ProductDetailId);
            productDetail.ClickCount = updateProductDetail.ClickCount;
            productDetailDal.Update(productDetail);
        }

        public void UpdatePurchasedCount(UpdateProductDetailPurchaseCountRequest updateProductDetail)
        {
            var productDetail = productDetailDal.GetById(updateProductDetail.ProductDetailId);
            productDetail.PurchaseCount = updateProductDetail.PurchaseCount;
            productDetailDal.Update(productDetail);
        }
    }
}
