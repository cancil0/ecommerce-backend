using Business.Abstract;
using Core.Base.Concrete;
using Core.Middleware.ExceptionMiddleware;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.RoleRequestDto;
using Entities.Dto.ResponseDto.RoleResponseDto;
using Entities.Enums;

namespace Business.Concrete
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        private readonly IRoleDal roleDal;
        public RoleService()
        {
            roleDal = Resolve<IRoleDal>();
        }
        public void AddRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                throw new AppException("Api.RoutePathNotFound", ExceptionTypes.NotFound.GetValue());

            Role role = new()
            {
                RoleName = roleName
            };

            roleDal.Insert(role);
        }

        public List<GetRoleResponse> GetRoles()
        {
            var roles = roleDal.GetAll();

            List<GetRoleResponse> result = new();

            foreach (var role in roles)
            {
                result.Add(new GetRoleResponse()
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName
                });
            }

            return result;
        }

        public void DeleteRole(string roleName)
        {
            var role = roleDal.GetAsNoTracking(x => x.RoleName == roleName);

            if (role == null)
                throw new AppException("Role.NotFound", ExceptionTypes.NotFound.GetValue());

            roleDal.Delete(role);
        }

        public void UpdateRole(UpdateRoleRequest updateRoleRequest)
        {
            var role = roleDal.GetAsNoTracking(x => x.RoleName == updateRoleRequest.OldRoleName);

            if (role == null)
                throw new AppException("Role.NotFound", ExceptionTypes.NotFound.GetValue());

            role.RoleName = updateRoleRequest.NewRoleName;

            roleDal.Update(role);
        }
    }
}
