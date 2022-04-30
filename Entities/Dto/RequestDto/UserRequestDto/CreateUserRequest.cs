using Entities.Dto.RequestDto.AddressRequestDto;

namespace Entities.Dto.RequestDto.UserRequestDto
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public int BirthDate { get; set; }
        public CreateUserDefaultRequest UserDefault { get; set; }
        public List<string> Roles { get; set; }
        public List<CreateAddressRequest> Addresses { get; set; }
    }
}
