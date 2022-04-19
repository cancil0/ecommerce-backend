﻿using Business.Abstract;
using Core.Base.Concrete;
using Entities.Dto.RequestDto.MerchantRequestDto;
using Entities.Dto.ResponseDto.MerchantResponseDto;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : BaseController
    {
        private readonly IMerchantService merchantService;

        public MerchantController()
        {
            merchantService = Resolve<IMerchantService>();
        }

        /// <summary>
        /// Get Merchant By Id
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        [HttpGet]
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
