using Business.Abstract;
using Core.Base.Concrete;
using Entities.Dto.RequestDto.LoginRequestDto;
using Entities.Dto.RequestDto.UserRequestDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : BaseController
    {
        private readonly ILoginService loginService;
        private readonly IConfiguration configuration;
        public LoginController(IConfiguration configuration)
        {
            loginService = Resolve<ILoginService>();
            this.configuration = configuration;
        }
        
        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public ActionResult<string> Login([FromBody] LoginRequest loginRequest)
        {
            return Ok(loginService.Login(loginRequest, configuration));
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ForgotMyPassword")]
        public ActionResult ForgotMyPassword([FromBody] GetUserRequest userRequest)
        {
            loginService.ForgotMyPassword(userRequest);
            return Ok();
        }
    }
}
