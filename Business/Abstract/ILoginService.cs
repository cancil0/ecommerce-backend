using Entities.Dto.RequestDto.LoginRequestDto;
using Entities.Dto.RequestDto.UserRequestDto;

namespace Business.Abstract
{
    public interface ILoginService
    {
        Task<string> Login(LoginRequest loginRequest, CancellationToken cancellationToken = default);
        void ForgotMyPassword(GetUserRequest getUserRequest);
    }
}
