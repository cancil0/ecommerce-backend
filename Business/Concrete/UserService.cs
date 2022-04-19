﻿using AutoMapper;
using Business.Abstract;
using Core.Attributes;
using Core.Base.Concrete;
using Core.Middleware.ExceptionMiddleware;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Enums;

namespace Business.Concrete
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserDal userDal;
        private readonly IRoleDal roleDal;
        private readonly IMapper mapper;
        public UserService()
        {
            mapper = Resolve<IMapper>();
            userDal = Resolve<IUserDal>();
            roleDal = Resolve<IRoleDal>();
        }

        [Loggable(IsResponseLoggable = false)]
        public User GetUser(GetUserRequest getUserRequest)
        {
            var user = userDal.Get(getUserRequest);

            return user;
        }

        [Loggable(IsResponseLoggable = false)]
        public User GetUserById(Guid id)
        {
            var user = userDal.GetById(id);

            if (user == null)
                throw new AppException("User.NotFound", ExceptionTypes.NotFound.GetValue());

            return user;
        }

        [Loggable(IsResponseLoggable = false)]
        public User GetUserAllInfo(GetUserRequest getUserRequest)
        {
            var User = userDal.Get(x => x.UserName == getUserRequest.UserName ||
                                                            x.Email == getUserRequest.Email ||
                                                            x.MobileNo == getUserRequest.MobileNo,
                                                            x => x.Addresses,
                                                            x => x.Cart,
                                                            x => x.Purchases,
                                                            x => x.UserRoles);

            if (User == null)
                throw new AppException("User.NotFound", ExceptionTypes.NotFound.GetValue());

            return User;
        }

        [Loggable(IsRequestLoggable = false)]
        public string CreateUser(CreateUserRequest createRequest)
        {
            var isUserExist = userDal.GetCreateUser(new GetUserRequest
                                {
                                    UserName = createRequest.UserName,
                                    Email = createRequest.Email,
                                    MobileNo = createRequest.MobileNo
                                }, false);

            if (isUserExist != null)
                throw new AppException("User.UserExist", ExceptionTypes.NotAllowed.GetValue());

            if(createRequest.Addresses == null)
                throw new AppException("User.EnterAddress", ExceptionTypes.NotAllowed.GetValue());

            var isDefaultCount = createRequest.Addresses.Count(x => x.IsDefault);

            foreach (var address in createRequest.Addresses)
            {
                if (string.IsNullOrEmpty(address.MobileNo))
                {
                    address.MobileNo = createRequest.MobileNo;
                }

                if (isDefaultCount > 1 && address.IsDefault)
                {
                    isDefaultCount--;
                    address.IsDefault = false;
                }
            }

            User user = new();
            mapper.Map(createRequest, user);

            var roles = roleDal.GetMany(x => createRequest.Roles.Contains(x.RoleName), x => x.UserRoles).Distinct();

            if (roles == null)
                throw new AppException("Role.NotFound", ExceptionTypes.NotFound.GetValue());

            user.UserRoles = new();

            foreach (var role in roles)
            {
                user.UserRoles.Add(new UserRole()
                {
                    RoleId = role.RoleId
                });
            }

            if(roles.Any(x => x.RoleName == "customer"))
            {
                user.Cart = new();
            }

            userDal.Insert(user);

            return user.UserName;
        }

        [Loggable(IsRequestLoggable = false, IsResponseLoggable = false)]
        public void UpdateUser(UserUpdateRequest userUpdate)
        {
            var user = userDal.Get(x => x.UserName == userUpdate.OldUserName);

            mapper.Map(userUpdate.UpdateUserRequest, user);

            userDal.Update(user);
        }

        public void DeleteUser(GetUserRequest getUser)
        {
            var user = userDal.Get(getUser);

            userDal.Delete(user);
        }
    }
}
