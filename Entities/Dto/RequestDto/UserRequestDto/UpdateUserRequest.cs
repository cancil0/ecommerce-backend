using Entities.Dto.RequestDto.AddressRequestDto;

namespace Entities.Dto.RequestDto.UserRequestDto
{
    public class UpdateUserRequest
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public int BirthDate { get; set; }
        public List<CreateAddressRequest> Addresses { get; set; }
    }
}
