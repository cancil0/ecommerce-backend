using Business.Abstract;
using Core.Abstract;
using Core.Concrete;
using Core.ExceptionHandler;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.LoginRequestDto;
using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Enums;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete
{
    public class LoginService : BaseService<User>, ILoginService
    {
        private readonly IUserDal userDal;
        private readonly ITokenService tokenService;

        public LoginService(IUserDal userDal,
                            ITokenService tokenService)
        {
            this.userDal = userDal;
            this.tokenService = tokenService;
        }

        public void ForgotMyPassword(GetUserRequest getUserRequest)
        {
            var user = userDal.Get(getUserRequest);
            user.Password = GeneratePassword();
            userDal.Update(user);
        }

        public async Task<string> Login(LoginRequest loginRequest, CancellationToken cancellationToken = default)
        {
            var predicate = PredicateBuilder.New<User>()
                .Or(x => x.Email == loginRequest.Email)
                .Or(x => x.UserName == loginRequest.UserName)
                .Or(x => x.MobileNo == loginRequest.MobileNo);

            var user = userDal.GetAsync(predicate, x => x.Include(x => x.UserRoles)
                                                            .ThenInclude(x => x.Role), false, cancellationToken);

            if (user.Result == null)
                throw new AppException("User.NotFound", ExceptionTypes.NotFound.GetValue());

            if (user.Result.Password != loginRequest.Password)
                throw new AppException("Login.CheckCredentials", ExceptionTypes.NotAllowed.GetValue());

            return await tokenService.GenerateToken(user.Result, cancellationToken);
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
