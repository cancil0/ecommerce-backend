using Business.Abstract;
using Core.Attributes;
using Entities.Dto.RequestDto.ProductDetailRequestDto;
using Entities.Dto.ResponseDto.ProductDetailResponseDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
    [Logger]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService productDetailService;
        public ProductDetailController(IProductDetailService productDetailService)
        {
            this.productDetailService = productDetailService;
        }

        /// <summary>
        /// Get Product's Detail
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("GetProductsDetail")]
        public ActionResult<GetProductDetailResponse> GetProductsDetail([FromBody] GetProductDetailRequest getProductDetail)
        {
            return Ok(productDetailService.GetProductsDetail(getProductDetail));
        }

        /// <summary>
        /// Add Product Detail
        /// </summary>
        /// <param name="addProductDetail"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProductDetail")]
        public ActionResult AddProductDetail([FromBody] AddProductDetailRequest addProductDetail)
        {
            productDetailService.AddProductDetail(addProductDetail);
            return Ok();
        }

        /// <summary>
        /// Update Product Detail
        /// </summary>
        /// <param name="updateProductDetail"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateProductDetail")]
        public ActionResult UpdateProductDetail([FromBody] UpdateProductDetailRequest updateProductDetail)
        {
            productDetailService.UpdateProductDetail(updateProductDetail);
            return Ok();
        }
    }
}
