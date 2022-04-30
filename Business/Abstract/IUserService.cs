using Entities.Concrete;
using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Dto.ResponseDto.UserResponseDto;

namespace Business.Abstract
{
    public interface IUserService
    {
        string CreateUser(CreateUserRequest createUser);
        void UpdateUser(UserUpdateRequest userUpdate);
        void DeleteUser(GetUserRequest getUser);
        GetUserResponse GetUserById(Guid id);
        GetUserResponse GetUser(GetUserRequest getUserRequest);
        GetUserResponse GetUserAllInfo(GetUserRequest getUserRequest);
    }
}
