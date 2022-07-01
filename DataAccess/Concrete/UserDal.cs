using Core.ExceptionHandler;
using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Enums;
using Infrastructure.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class UserDal : GenericDal<User>, IUserDal
    {
        public UserDal(Context context) : base(context) {}
        public User Get(GetUserRequest userRequest, bool throwException)
        {
            var user = dbSet
                        .Include(x => x.UserRoles)
                            .ThenInclude(x => x.Role)
                        .SingleOrDefault(x => x.UserName == userRequest.UserName ||
                                                x.MobileNo == userRequest.MobileNo ||
                                                x.Email == userRequest.Email);

            if (user == null && throwException)
                throw new AppException("User.NotFound", ExceptionTypes.NotFound.GetValue());

            return user;
        }

        public async Task<User> GetAsync(GetUserRequest userRequest, bool throwException, CancellationToken cancellationToken)
        {
            var user = dbSet
                        .Include(x => x.UserRoles)
                            .ThenInclude(x => x.Role)
                        .SingleOrDefaultAsync(x => x.UserName == userRequest.UserName ||
                                                x.MobileNo == userRequest.MobileNo ||
                                                x.Email == userRequest.Email, 
                                                cancellationToken);

            if (user == null && throwException)
                throw new AppException("User.NotFound", ExceptionTypes.NotFound.GetValue());

            return await user;
        }

        public User GetCreateUser(GetUserRequest userRequest, bool throwException)
        {
            var user = dbSet
                        .IgnoreQueryFilters()
                        .Include(x => x.UserRoles)
                            .ThenInclude(x => x.Role)
                        .SingleOrDefault(x => x.UserName == userRequest.UserName ||
                                                x.MobileNo == userRequest.MobileNo ||
                                                x.Email == userRequest.Email);

            if (user == null && throwException)
                throw new AppException("User.NotFound", ExceptionTypes.NotFound.GetValue());

            return user;
        }
    }
}
