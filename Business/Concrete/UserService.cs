using AutoMapper;
using Business.Abstract;
using Core.Attributes;
using Core.Concrete;
using Core.ExceptionHandler;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Dto.ResponseDto.UserResponseDto;
using Entities.Dto.ResponseDto.UserRoleResponseDto;
using Entities.Enums;

namespace Business.Concrete
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserDal userDal;
        private readonly IRoleDal roleDal;
        private readonly IMapper mapper;
        public UserService(IUserDal userDal, 
                           IRoleDal roleDal, 
                           IMapper mapper)
        {
            this.userDal = userDal;
            this.roleDal = roleDal;
            this.mapper = mapper;
        }

        [Loggable(IsResponseLoggable = false)]
        public GetUserResponse GetUser(GetUserRequest getUserRequest)
        {
            var user = userDal.Get(getUserRequest);
            return mapper.Map<GetUserResponse>(user);
        }

        [Loggable(IsResponseLoggable = false)]
        public GetUserResponse GetUserById(Guid id)
        {
            var user = userDal.GetById(id);

            if (user == null)
                throw new AppException("User.NotFound", ExceptionTypes.NotFound.GetValue());

            return mapper.Map<GetUserResponse>(user);
        }

        [Loggable(IsResponseLoggable = false)]
        public GetUserResponse GetUserAllInfo(GetUserRequest getUserRequest)
        {
            var user = userDal.Get(x => x.UserName == getUserRequest.UserName ||
                                                            x.Email == getUserRequest.Email ||
                                                            x.MobileNo == getUserRequest.MobileNo,
                                                            x => x.Addresses,
                                                            x => x.Cart,
                                                            x => x.Purchases,
                                                            x => x.UserRoles,
                                                            x => x.UserDefault,
                                                            x => x.UserRoles);

            if (user == null)
                throw new AppException("User.NotFound", ExceptionTypes.NotFound.GetValue());

            var result = mapper.Map<GetUserResponse>(user);
            foreach (var userRole in user.UserRoles)
            {
                result.UserRoles.Add(new UserRoleResponse()
                {
                    RoleId = userRole.RoleId,
                    RoleName = userRole.Role?.RoleName
                });
            }

            return result;
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

            var user = mapper.Map<User>(createRequest);

            var roles = roleDal.GetMany(x => createRequest.Roles.Contains(x.RoleName), x => x.UserRoles).Distinct();

            if (roles == null)
                throw new AppException("Role.NotFound", ExceptionTypes.NotFound.GetValue());

            foreach (var role in roles)
            {
                user.UserRoles.Add(new UserRole()
                {
                    RoleId = role.RoleId
                });
            }

            if(roles.Any(x => x.RoleName == UserRoles.Customer.GetValue()))
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
