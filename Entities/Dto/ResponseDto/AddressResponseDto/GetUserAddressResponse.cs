using Entities.EntityAttributes;

namespace Entities.Dto.ResponseDto.AddressResponseDto
{
    public class GetUserAddressResponse
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string AddressInfo { get; set; }
        public string AddressType { get; set; }

        [NotLoggableProperty]
        public string MobileNo { get; set; }
        public bool IsDefault { get; set; }
    }
}
