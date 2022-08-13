using Business.Abstract;
using Core.Attributes;
using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Dto.RequestDto.UserRoleRequestDto;
using Entities.Dto.ResponseDto.UserRoleResponseDto;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.SystemController
{
    [Route("api/[controller]")]
    [ApiController]
    [Logger]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService userRoleService;
        public UserRoleController(IUserRoleService userRoleService)
        {
            this.userRoleService = userRoleService;
        }

        /// <summary>
        /// Get All User Roles
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUserRoles")]
        [Logger(IsResponseLoggable = false)]
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
        [Logger(IsRequestLoggable = false)]
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
