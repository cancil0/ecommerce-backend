using Business.Abstract;
using Core.Attributes;
using Entities.Dto.RequestDto.MerchantRequestDto;
using Entities.Dto.ResponseDto.MerchantResponseDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
    [Logger]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantService merchantService;
        public MerchantController(IMerchantService merchantService)
        {
            this.merchantService = merchantService;
        }

        /// <summary>
        /// Get Merchant By Id
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetMerchant")]
        public ActionResult<GetMerchantResponse> GetMerchant([FromQuery] Guid merchantId)
        {
            return Ok(merchantService.GetMerchant(merchantId));
        }

        /// <summary>
        /// Add Merchant
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPost]
        [UnitofWork]
        [Route("AddMerchant")]
        public ActionResult AddMerchant([FromBody] AddMerchantRequest addMerchant)
        {
            merchantService.AddMerchant(addMerchant);
            return Ok();
        }

        /// <summary>
        /// Update Merchant
        /// </summary>
        /// <param name="updateMerchant"></param>
        /// <returns></returns>
        [HttpPut]
        [UnitofWork]
        [Route("UpdateMerchant")]
        public ActionResult UpdateMerchant([FromBody] UpdateMerchantRequest updateMerchant)
        {
            merchantService.UpdateMerchant(updateMerchant);
            return Ok();
        }

        /// <summary>
        /// Delete Merchant
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        [HttpDelete]
        [UnitofWork]
        [Route("DeleteMerchant")]
        public ActionResult DeleteMerchant([FromQuery] Guid merchantId)
        {
            merchantService.DeleteMerchant(merchantId);
            return Ok();
        }

        /// <summary>
        /// Give Feedback To Merchant
        /// </summary>
        /// <param name="updateMerchant"></param>
        /// <returns></returns>
        [HttpPut]
        [UnitofWork]
        [Route("GiveFeedbackToMerchant")]
        public ActionResult GiveFeedbackToMerchant([FromBody] GiveFeedbackToMerchantRequest giveFeedback)
        {
            merchantService.GiveFeedbackToMerchant(giveFeedback);
            return Ok();
        }
    }
}
