using Business.Abstract;
using Core.Attributes;
using Entities.Dto.RequestDto.ApiRoleRequestDto;
using Entities.Dto.ResponseDto.ApiRoleResponse;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.SystemController
{
    [Route("api/[controller]")]
    [ApiController]
    [Logger]
    public class ApiRoleController : ControllerBase
    {
        private readonly IApiRoleService apiRoleService;
        public ApiRoleController(IApiRoleService apiRoleService)
        {
            this.apiRoleService = apiRoleService;
        }

        /// <summary>
        /// Get All ApiRoles
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetApiRoles")]
        public ActionResult<List<GetApiRoleResponse>> GetApiRoles()
        {
            return Ok(apiRoleService.GetApiRoles());
        }

        /// <summary>
        /// Add ApiRole
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [UnitofWork]
        [Route("AddApiRole")]
        public ActionResult AddApiRole([FromBody] ApiRoleRequest apiRoleRequest)
        {
            apiRoleService.AddApiRole(apiRoleRequest);
            return Ok();
        }

        /// <summary>
        /// Delete ApiRole
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [UnitofWork]
        [Route("DeleteApiRole")]
        public ActionResult DeleteApiRole([FromBody] ApiRoleRequest apiRoleRequest)
        {
            apiRoleService.DeleteApiRole(apiRoleRequest);
            return Ok();
        }
    }
}
