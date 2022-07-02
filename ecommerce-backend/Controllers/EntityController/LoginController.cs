using Business.Abstract;
using Core.Attributes;
using Entities.Dto.RequestDto.LoginRequestDto;
using Entities.Dto.RequestDto.UserRequestDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [Logger(IsRequestLoggable = false, IsResponseLoggable = false)]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        
        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequest loginRequest, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Ok(await loginService.Login(loginRequest, cancellationToken));
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [UnitofWork]
        [Route("ForgotMyPassword")]
        public ActionResult ForgotMyPassword([FromBody] GetUserRequest userRequest)
        {
            loginService.ForgotMyPassword(userRequest);
            return Ok();
        }
    }
}
