using Entities.Dto.RequestDto.ApiRoleRequestDto;
using Entities.Dto.ResponseDto.ApiRoleResponse;

namespace Business.Abstract
{
    public interface IApiRoleService
    {
        List<GetApiRoleResponse> GetApiRoles();
        void AddApiRole(ApiRoleRequest apiRoleRequest);
        void DeleteApiRole(ApiRoleRequest apiRoleRequest);
    }
}
