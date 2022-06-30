using Business.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.CarouselRequestDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarouselController : ControllerBase
    {
        private readonly ICarouselService carouselService;
        public CarouselController(ICarouselService carouselService)
        {
            this.carouselService = carouselService;
        }

        /// <summary>
        /// Get Carousel
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetCarousel")]
        public ActionResult GetCarousel([FromQuery] Guid carouselId)
        {
            return Ok(carouselService.GetCarousel(carouselId));
        }

        /// <summary>
        /// Get Carousels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetCarousels")]
        public ActionResult GetCarousels()
        {
            return Ok(carouselService.GetCarousels());
        }

        /// <summary>
        /// Add Carousel
        /// </summary>
        /// <param name="addCarousel"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("AddCarousel")]
        public ActionResult AddCarousel([FromBody] AddCarouselRequest addCarousel)
        {
            carouselService.AddCarousel(addCarousel);
            return Ok();
        }

        /// <summary>
        /// Update Carousel
        /// </summary>
        /// <param name="carouselUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateCarousel")]
        public ActionResult UpdateCarousel([FromBody] Carousel carouselUpdate)
        {
            carouselService.UpdateCarousel(carouselUpdate);
            return Ok();
        }

        /// <summary>
        /// Delete Carousel
        /// </summary>
        /// <param name="carouselId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteCarousel")]
        public ActionResult DeleteCarousel([FromQuery] Guid carouselId)
        {
            carouselService.DeleteCarousel(carouselId);
            return Ok();
        }
    }
}
