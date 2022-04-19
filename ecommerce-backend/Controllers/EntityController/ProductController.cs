using Business.Abstract;
using Core.Base.Concrete;
using Entities.Dto.RequestDto.ProductRequestDto;
using Entities.Dto.ResponseDto.ProductResponseDto;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController()
        {
            productService = Resolve<IProductService>();
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProduct")]
        public ActionResult<GetProductResponse> GetProduct([FromQuery] Guid productId)
        {
            return Ok(productService.GetProduct(productId));
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="addProduct"></param>
        /// <returns></returns>
        [HttpPost]
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
        [Route("DeleteProduct")]
        public ActionResult DeleteProduct([FromBody] DeleteProductRequest deleteProduct)
        {
            productService.DeleteProduct(deleteProduct);
            return Ok();
        }
    }
}
