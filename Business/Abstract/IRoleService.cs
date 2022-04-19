using Entities.Dto.RequestDto.RoleRequestDto;
using Entities.Dto.ResponseDto.RoleResponseDto;

namespace Business.Abstract
{
    public interface IRoleService
    {
        List<GetRoleResponse> GetRoles();
        void AddRole(string roleName);
        void DeleteRole(string roleName);
        void UpdateRole(UpdateRoleRequest updateApiRequest);
    }
}
