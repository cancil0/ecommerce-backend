using AutoMapper;
using Business.Abstract;
using Core.Base.Concrete;
using Core.Middleware.ExceptionMiddleware;
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
        public ProductDetailService()
        {
            productDetailDal = Resolve<IProductDetailDal>();
            productDal = Resolve<IProductDal>();
            merchantDal = Resolve<IMerchantDal>();
            mapper = Resolve<IMapper>();
        }

        public void AddProductDetail(AddProductDetailRequest addProductDetail)
        {
            if (addProductDetail.ProductId == Guid.Empty)
            {
                throw new AppException("ProductDetail.ChooseProductToAdd", ExceptionTypes.BadRequest.GetValue());
            }

            if (addProductDetail.MerchantId == Guid.Empty)
            {
                throw new AppException("ProductDetail.ChooseMerchantToAdd", ExceptionTypes.BadRequest.GetValue());
            }

            if (addProductDetail.Count < 0)
            {
                throw new AppException("ProductDetail.CheckCount", ExceptionTypes.BadRequest.GetValue());
            }

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
                    MerchantName = productDetail.Merchant.MerchantName
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
    }
}
