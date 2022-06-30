using Business.Abstract;
using Core.Abstract;
using Core.Attributes;
using Core.Concrete;
using Core.ExceptionHandler;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.LoginRequestDto;
using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Enums;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete
{
    public class LoginService : BaseService<User>, ILoginService
    {
        private readonly IUserDal userDal;
        private readonly ITokenService tokenService;

        public LoginService()
        {
            userDal = Resolve<IUserDal>();
            tokenService = Resolve<ITokenService>();
        }

        [Loggable(IsRequestLoggable = false)]
        public void ForgotMyPassword(GetUserRequest getUserRequest)
        {
            var user = userDal.Get(getUserRequest);
            user.Password = GeneratePassword();
            userDal.Update(user);
        }

        [Loggable(IsRequestLoggable = false, IsResponseLoggable = false)]
        public async Task<string> Login(LoginRequest loginRequest)
        {
            var user = userDal.Get(new GetUserRequest()
            {
                Email = loginRequest.Email,
                MobileNo = loginRequest.MobileNo,
                UserName = loginRequest.UserName
            });

            if (user.Password != loginRequest.Password)
                throw new AppException("Login.CheckCredentials", ExceptionTypes.NotAllowed.GetValue());

            return await tokenService.GenerateToken(user);
        }

        private static string GeneratePassword(int length = 12)
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*_-";

            Random random = new();
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
    }
}
