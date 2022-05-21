using Business.Abstract;
using Core.Base.Concrete;
using Entities.Dto.RequestDto.ProductRequestDto;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        [Route("GetProduct")]
        public ActionResult GetProduct([FromQuery] Guid productId)
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
        public ActionResult GetCategoryProducts([FromQuery] Guid categoryId)
        {
            return Ok(productService.GetCategoryProducts(categoryId));
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
