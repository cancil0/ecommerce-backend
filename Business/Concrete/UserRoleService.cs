using Business.Abstract;
using Core.Attributes;
using Core.Concrete;
using Core.ExceptionHandler;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Dto.RequestDto.UserRoleRequestDto;
using Entities.Dto.ResponseDto.UserRoleResponseDto;
using Entities.Enums;

namespace Business.Concrete
{
    public class UserRoleService : BaseService<UserRole>, IUserRoleService
    {
        private readonly IUserRoleDal userRoleDal;
        private readonly IUserDal userDal;
        private readonly IRoleDal roleDal;
        public UserRoleService(IUserRoleDal userRoleDal, 
                               IUserDal userDal, 
                               IRoleDal roleDal)
        {
            this.userRoleDal = userRoleDal;
            this.userDal = userDal;
            this.roleDal = roleDal;
        }
        public void AddUserRole(AddUserRoleRequest userRoleRequest)
        {
            var user = userDal.GetById(userRoleRequest.UserId);

            if (user == null)
                throw new AppException("User.NotFound", ExceptionTypes.NotFound.GetValue());

            var role = roleDal.GetById(userRoleRequest.RoleId);

            if (role == null)
                throw new AppException("Role.NotFound", ExceptionTypes.NotFound.GetValue());

            UserRole userRole = new() 
            { 
                RoleId = userRoleRequest.RoleId,
                UserId = userRoleRequest.UserId
            };

            userRoleDal.Insert(userRole);
        }

        public void DeleteUserRole(AddUserRoleRequest userRoleRequest)
        {
            var userRole = userRoleDal.Get(x => x.RoleId == userRoleRequest.RoleId && x.UserId == userRoleRequest.UserId);

            if (userRole == null)
                throw new AppException("UserRole.NotFound", ExceptionTypes.NotFound.GetValue());

            userRoleDal.Delete(userRole);
        }

        [Loggable(IsResponseLoggable = false)]
        public List<UserRoleResponse> GetUserRoles(GetUserRequest userRequest)
        {
            var user = userDal.Get(userRequest);

            var userRoles = userRoleDal.GetMany(x => x.UserId == user.UserId, x => x.Role);

            if (userRoles.Count == 0)
                throw new AppException("UserRole.NotFound", ExceptionTypes.NotFound.GetValue());

            List<UserRoleResponse> userRoleResponses = new();

            foreach (var role in userRoles)
            {
                userRoleResponses.Add(new UserRoleResponse()
                {
                    RoleId = role.RoleId,
                    RoleName = role.Role.RoleName
                });
            }

            return userRoleResponses;
            
        }

    }
}
