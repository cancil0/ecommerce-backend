using Business.Abstract;
using Core.Base.Concrete;
using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Dto.RequestDto.UserRoleRequestDto;
using Entities.Dto.ResponseDto.UserRoleResponseDto;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.SystemController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : BaseController
    {
        private readonly IUserRoleService userRoleService;
        public UserRoleController()
        {
            userRoleService = Resolve<IUserRoleService>();
        }

        /// <summary>
        /// Get All User Roles
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUserRoles")]
        public ActionResult<List<UserRoleResponse>> GetUserRoles([FromBody] GetUserRequest getUser)
        {
            return Ok(userRoleService.GetUserRoles(getUser));
        }

        /// <summary>
        /// Add User Role
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUserRole")]
        public ActionResult AddUserRole([FromBody] AddUserRoleRequest addUserRole)
        {
            userRoleService.AddUserRole(addUserRole);
            return Ok();
        }

        /// <summary>
        /// Delete User Role
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteUserRole")]
        public ActionResult DeleteUserRole([FromBody] AddUserRoleRequest addUserRole)
        {
            userRoleService.DeleteUserRole(addUserRole);
            return Ok();
        }
    }
}
