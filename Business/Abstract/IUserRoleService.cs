using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Dto.RequestDto.UserRoleRequestDto;
using Entities.Dto.ResponseDto.UserRoleResponseDto;

namespace Business.Abstract
{
    public interface IUserRoleService
    {
        void AddUserRole(AddUserRoleRequest userRoleRequest);

        void DeleteUserRole(AddUserRoleRequest userRoleRequest);

        List<UserRoleResponse> GetUserRoles(GetUserRequest userRequest);

    }
}
