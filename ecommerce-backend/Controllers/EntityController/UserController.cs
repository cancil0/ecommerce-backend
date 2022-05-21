using Business.Abstract;
using Core.Base.Concrete;
using Entities.Dto.RequestDto.UserRequestDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        public UserController()
        {
            userService = Resolve<IUserService>();
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById/{id}")]
        public ActionResult GetUserById([FromRoute] Guid id)
        {
            return Ok(userService.GetUserById(id));
        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUser")]
        public ActionResult GetUser([FromBody] GetUserRequest getUser)
        {
            return Ok(userService.GetUser(getUser));
        }

        /// <summary>
        /// Gets Cutomer All Info
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUserAllInfo")]
        public ActionResult GetUserAllInfo([FromBody] GetUserRequest getUser)
        {
            return Ok(userService.GetUserAllInfo(getUser));
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateUser")]
        [AllowAnonymous]
        public ActionResult CreateUser([FromBody] CreateUserRequest userRequest)
        {
            return Ok(userService.CreateUser(userRequest));
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUser")]
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
        [Route("DeleteUser")]
        public ActionResult DeleteUser([FromBody] GetUserRequest getUser)
        {
            userService.DeleteUser(getUser);
            return Ok();
        }
    }
}
