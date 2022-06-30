using Entities.Dto.RequestDto.LoginRequestDto;
using Entities.Dto.RequestDto.UserRequestDto;

namespace Business.Abstract
{
    public interface ILoginService
    {
        Task<string> Login(LoginRequest loginRequest);
        void ForgotMyPassword(GetUserRequest getUserRequest);
    }
}
