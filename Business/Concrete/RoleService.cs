using Business.Abstract;
using Core.Attributes;
using Core.Concrete;
using Core.ExceptionHandler;
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
        public RoleService(IRoleDal roleDal)
        {
            this.roleDal = roleDal;
        }

        [UnitofWork]
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

        [UnitofWork]
        public void DeleteRole(string roleName)
        {
            var role = roleDal.Get(x => x.RoleName == roleName);

            if (role == null)
                throw new AppException("Role.NotFound", ExceptionTypes.NotFound.GetValue());

            roleDal.Delete(role);
        }

        [UnitofWork]
        public void UpdateRole(UpdateRoleRequest updateRoleRequest)
        {
            var role = roleDal.Get(x => x.RoleName == updateRoleRequest.OldRoleName);

            if (role == null)
                throw new AppException("Role.NotFound", ExceptionTypes.NotFound.GetValue());

            role.RoleName = updateRoleRequest.NewRoleName;

            roleDal.Update(role);
        }
    }
}
