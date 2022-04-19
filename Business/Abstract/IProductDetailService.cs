using Entities.Dto.RequestDto.ProductDetailRequestDto;
using Entities.Dto.ResponseDto.ProductDetailResponseDto;

namespace Business.Abstract
{
    public interface IProductDetailService
    {
        List<GetProductDetailResponse> GetProductsDetail(GetProductDetailRequest getProductDetail);
        void AddProductDetail(AddProductDetailRequest addProductDetail);
        void UpdateProductDetail(UpdateProductDetailRequest updateProductDetail);
    }
}
