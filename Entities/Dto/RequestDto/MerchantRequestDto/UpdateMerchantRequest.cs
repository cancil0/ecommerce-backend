using Entities.Dto.RequestDto.AddressRequestDto;

namespace Entities.Dto.RequestDto.MerchantRequestDto
{
    public class UpdateMerchantRequest
    {
        public Guid MerchantId { get; set; }
        public string MerchantName { get; set; }
        public decimal MerchantPoint { get; set; }
        public long RegistrationNo { get; set; }
        public CreateAddressRequest Address { get; set; }
    }
}
