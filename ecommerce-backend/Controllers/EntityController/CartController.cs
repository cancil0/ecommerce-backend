using Business.Abstract;
using Entities.Dto.RequestDto.CartRequestDto;
using Entities.Dto.ResponseDto.CartResponseDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        /// <summary>
        /// Get Cart
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserCart")]
        public ActionResult<GetUserCartResponse> GetUserCart([FromQuery] Guid userId)
        {
            return Ok(cartService.GetUserCart(userId));
        }

        /// <summary>
        /// Add Product To Cart
        /// </summary>
        /// <param name="addProduct"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProductToCart")]
        public ActionResult AddProductToCart([FromBody] AddProductToCartRequest addProduct)
        {
            cartService.AddProductToCart(addProduct);
            return Ok();
        }

        /// <summary>
        /// Remove Product From Cart
        /// </summary>
        /// <param name="removeProduct"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("RemoveProductFromCart")]
        public ActionResult RemoveProductFromCart([FromBody] RemoveProductFromCartRequest removeProduct)
        {
            cartService.RemoveProductFromCart(removeProduct);
            return Ok();
        }

        /// <summary>
        /// Remove All Products From Cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("RemoveAllProductsFromCart")]
        public ActionResult RemoveAllProductsFromCart([FromQuery] Guid cartId)
        {
            cartService.RemoveAllProductsFromCart(cartId);
            return Ok();
        }
    }
}
