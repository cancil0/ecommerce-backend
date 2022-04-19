using Core.Middleware.ExceptionMiddleware;
using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class EfUserRepository : GenericDal<User>, IUserDal
    {
        public User Get(GetUserRequest userRequest, bool throwException)
        {
            var user =  dbSet
                        .Include(x => x.UserRoles)
                            .ThenInclude(x => x.Role)
                        .SingleOrDefault(x => x.UserName == userRequest.UserName || 
                                                x.MobileNo == userRequest.MobileNo ||
                                                x.Email == userRequest.Email);

            if (user == null && throwException)
                throw new AppException("User.NotFound", ExceptionTypes.NotFound.GetValue());

            return user;
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
