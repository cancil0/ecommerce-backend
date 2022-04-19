using Entities.Concrete;
using Entities.Dto.RequestDto.UserRequestDto;

namespace Business.Abstract
{
    public interface IUserService
    {
        string CreateUser(CreateUserRequest createUser);
        void UpdateUser(UserUpdateRequest userUpdate);
        void DeleteUser(GetUserRequest getUser);
        User GetUserById(Guid id);
        User GetUser(GetUserRequest getUserRequest);
        User GetUserAllInfo(GetUserRequest getUserRequest);
    }
}
