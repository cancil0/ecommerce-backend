﻿using Business.Abstract;
using Core.Base.Concrete;
using Entities.Dto.RequestDto.RoleRequestDto;
using Entities.Dto.ResponseDto.RoleResponseDto;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.SystemController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService roleService;
        public RoleController()
        {
            roleService = Resolve<IRoleService>();
        }

        /// <summary>
        /// Get All Role
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRoles")]
        public ActionResult<List<GetRoleResponse>> GetRoles()
        {
            return Ok(roleService.GetRoles());
        }

        /// <summary>
        /// Add Role
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddRole")]
        public ActionResult AddRole([FromBody] string roleName)
        {
            roleService.AddRole(roleName);
            return Ok();
        }

        /// <summary>
        /// Update Role
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateRole")]
        public ActionResult UpdateRole([FromBody] UpdateRoleRequest updateRoleRequest)
        {
            roleService.UpdateRole(updateRoleRequest);
            return Ok();
        }

        /// <summary>
        /// Delete Role
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteRole")]
        public ActionResult DeleteRole([FromBody] string roleName)
        {
            roleService.DeleteRole(roleName);
            return Ok();
        }
    }
}
