using Entities.Dto.RequestDto.AddressRequestDto;
using Entities.Dto.ResponseDto.ProductDetailResponseDto;

namespace Entities.Dto.ResponseDto.MerchantResponseDto
{
    public class GetMerchantResponse
    {
        public string MerchantName { get; set; }
        public decimal MerchantPoint { get; set; }
        public CreateAddressRequest Address { get; set; }
        public List<GetProductDetailResponse> ProductDetails { get; set; }
    }
}
