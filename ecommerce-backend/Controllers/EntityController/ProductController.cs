using Business.Abstract;
using Core.Attributes;
using Entities.Dto.RequestDto.ProductRequestDto;
using Entities.Dto.ResponseDto.ProductResponseDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
    [Logger]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetProduct")]
        public ActionResult<GetProductResponse> GetProduct([FromQuery] Guid productId)
        {
            return Ok(productService.GetProduct(productId));
        }

        /// <summary>
        /// Get Category's Products
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetCategoryProducts")]
        public ActionResult<List<GetProductResponse>> GetCategoryProducts([FromQuery] Guid categoryId)
        {
            return Ok(productService.GetCategoryProducts(categoryId));
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="addProduct"></param>
        /// <returns></returns>
        [HttpPost]
        [UnitofWork]
        [Route("AddProduct")]
        public ActionResult AddProduct([FromBody] AddProductRequest addProduct)
        {
            productService.AddProduct(addProduct);
            return Ok();
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="updateProduct"></param>
        /// <returns></returns>
        [HttpPut]
        [UnitofWork]
        [Route("UpdateProduct")]
        public ActionResult UpdateProduct([FromBody] UpdateProductRequest updateProduct)
        {
            productService.UpdateProduct(updateProduct);
            return Ok();
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="deleteProduct"></param>
        /// <returns></returns>
        [HttpDelete]
        [UnitofWork]
        [Route("DeleteProduct")]
        public ActionResult DeleteProduct([FromBody] DeleteProductRequest deleteProduct)
        {
            productService.DeleteProduct(deleteProduct);
            return Ok();
        }
    }
}
