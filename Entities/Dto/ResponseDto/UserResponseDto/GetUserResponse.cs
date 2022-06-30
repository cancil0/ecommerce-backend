using Entities.Dto.ResponseDto.AddressResponseDto;
using Entities.Dto.ResponseDto.CartResponseDto;
using Entities.Dto.ResponseDto.UserRoleResponseDto;
using Entities.EntityAttributes;

namespace Entities.Dto.ResponseDto.UserResponseDto
{
    public class GetUserResponse
    {
        public GetUserResponse()
        {
            UserRoles = new();
        }
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string UserName { get; set; }

        [NotLoggableProperty]
        public string Password { get; set; }

        public int BirthDate { get; set; }

        public string Email { get; set; }

        public string MobileNo { get; set; }

        public string Gender { get; set; }

        public GetUserCartResponse Cart { get; set; }

        public GetUserDefaultResponse UserDefault { get; set; }

        public List<GetUserAddressResponse> Addresses { get; set; }

        public List<UserRoleResponse> UserRoles { get; set; }
    }
}
