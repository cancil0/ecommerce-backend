using Business.Abstract;
using Core.Attributes;
using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Dto.ResponseDto.UserResponseDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById/{id}")]
        [Logger(IsResponseLoggable = false)]
        public ActionResult<GetUserResponse> GetUserById([FromRoute] Guid id)
        {
            return Ok(userService.GetUserById(id));
        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUser")]
        [Logger(IsResponseLoggable = false)]
        public ActionResult<GetUserResponse> GetUser([FromBody] GetUserRequest getUser)
        {
            return Ok(userService.GetUser(getUser));
        }

        /// <summary>
        /// Gets Cutomer All Info
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUserAllInfo")]
        [Logger(IsResponseLoggable = true)]
        public ActionResult<GetUserResponse> GetUserAllInfo([FromBody] GetUserRequest getUser)
        {
            return Ok(userService.GetUserAllInfo(getUser));
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPost]
        [UnitofWork]
        [Route("CreateUser")]
        [AllowAnonymous]
        [Logger(IsRequestLoggable = false)]
        public ActionResult<string> CreateUser([FromBody] CreateUserRequest userRequest)
        {
            return Ok(userService.CreateUser(userRequest));
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPut]
        [UnitofWork]
        [Route("UpdateUser")]
        [Logger(IsRequestLoggable = false)]
        public ActionResult UpdateUser([FromBody] UserUpdateRequest userUpdate)
        {
            userService.UpdateUser(userUpdate);
            return Ok();
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpDelete]
        [UnitofWork]
        [Route("DeleteUser")]
        [Logger(IsRequestLoggable = false)]
        public ActionResult DeleteUser([FromBody] GetUserRequest getUser)
        {
            userService.DeleteUser(getUser);
            return Ok();
        }
    }
}
