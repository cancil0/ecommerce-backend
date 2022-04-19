using Entities.Dto.RequestDto.LoginRequestDto;
using Entities.Dto.RequestDto.UserRequestDto;
using Microsoft.Extensions.Configuration;

namespace Business.Abstract
{
    public interface ILoginService
    {
        string Login(LoginRequest loginRequest, IConfiguration configuration);
        void ForgotMyPassword(GetUserRequest getUserRequest);
    }
}
