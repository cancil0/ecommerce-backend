using Entities.Dto.RequestDto.AddressRequestDto;
using Entities.Dto.RequestDto.ProductDetailRequestDto;

namespace Entities.Dto.RequestDto.MerchantRequestDto
{
    public class AddMerchantRequest
    {
        public string MerchantName { get; set; }
        public decimal MerchantPoint { get; set; }
        public long RegistrationNo { get; set; }
        public CreateAddressRequest Address { get; set; }
    }
}
