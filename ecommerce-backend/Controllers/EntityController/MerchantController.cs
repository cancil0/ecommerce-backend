using Business.Abstract;
using Entities.Dto.RequestDto.MerchantRequestDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
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
        public ActionResult GetMerchant([FromQuery] Guid merchantId)
        {
            return Ok(merchantService.GetMerchant(merchantId));
        }

        /// <summary>
        /// Add Merchant
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPost]
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
        [Route("GiveFeedbackToMerchant")]
        public ActionResult GiveFeedbackToMerchant([FromBody] GiveFeedbackToMerchantRequest giveFeedback)
        {
            merchantService.GiveFeedbackToMerchant(giveFeedback);
            return Ok();
        }
    }
}
