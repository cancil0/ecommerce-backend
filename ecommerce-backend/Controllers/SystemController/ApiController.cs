using Business.Abstract;
using Core.Attributes;
using Entities.Dto.RequestDto.ApiRequestDto;
using Entities.Dto.ResponseDto.ApiResponseDto;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.SystemController
{
    [Route("api/[controller]")]
    [ApiController]
    [Logger]
    public class ApiController : ControllerBase
    {
        private readonly IApiService apiService;
        public ApiController(IApiService apiService)
        {
            this.apiService = apiService;
        }

        /// <summary>
        /// Get All Api
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetApis")]
        public ActionResult<List<GetApiResponse>> GetApis()
        {
            return Ok(apiService.GetApis());
        }

        /// <summary>
        /// Add Api
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddApi")]
        public ActionResult AddApi([FromBody] string apiPath)
        {
            apiService.AddApi(apiPath);
            return Ok();
        }

        /// <summary>
        /// Update Api
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateApi")]
        public ActionResult UpdateApi([FromBody] UpdateApiRequest updateApiRequest)
        {
            apiService.UpdateApi(updateApiRequest);
            return Ok();
        }

        /// <summary>
        /// Delete Api
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteApi")]
        public ActionResult DeleteApi([FromBody] string apiPath)
        {
            apiService.DeleteApi(apiPath);
            return Ok();
        }
    }
}
