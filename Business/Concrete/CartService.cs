using Business.Abstract;
using Core.Concrete;
using Core.ExceptionHandler;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.CartRequestDto;
using Entities.Dto.ResponseDto.CartResponseDto;
using Entities.Dto.ResponseDto.ProductDetailResponseDto;
using Entities.Dto.ResponseDto.ProductResponseDto;
using Entities.Enums;

namespace Business.Concrete
{
    public class CartService : BaseService<Cart>, ICartService
    {
        private readonly ICartDal cartDal;
        private readonly ICartProductDal cartProductDal;
        private readonly IProductDal productDal;
        public CartService(ICartDal cartDal, 
                           ICartProductDal cartProductDal, 
                           IProductDal productDal)
        {
            this.cartDal = cartDal;
            this.cartProductDal = cartProductDal;
            this.productDal = productDal;
        }

        public void AddProductToCart(AddProductToCartRequest addProduct)
        {
            var product = productDal.GetById(addProduct.ProductId);

            if (product == null)
            {
                throw new AppException("Product.NotFound", ExceptionTypes.NotFound.GetValue());
            }

            var cartProduct = new CartProduct()
            {
                CartId = addProduct.CartId,
                ProductId = addProduct.ProductId,
            };
            cartProductDal.Insert(cartProduct);
        }

        public void RemoveProductFromCart(RemoveProductFromCartRequest removeProduct)
        {
            var product = productDal.GetById(removeProduct.ProductId);

            var cartProduct = cartProductDal.Get(x => x.ProductId == removeProduct.ProductId && x.CartId == removeProduct.CartId);

            if(cartProduct == null)
            {
                throw new AppException("Cart.ProductHasRemoved", ExceptionTypes.BadRequest.GetValue());
            }

            cartProductDal.Delete(cartProduct);
        }

        public void RemoveAllProductsFromCart(Guid cartId)
        {
            var cartProduct = cartProductDal.GetMany(x =>  x.CartId == cartId);

            if (cartProduct.Count == 0)
            {
                throw new AppException("Cart.ProductHasRemoved", ExceptionTypes.BadRequest.GetValue());
            }

            cartProductDal.DeleteBulk(cartProduct);
        }

        public GetUserCartResponse GetUserCart(Guid userId)
        {
            var cart = cartDal.GetUserCart(userId);

            var products = cartProductDal.GetMany(x => x.CartId == cart.CartId, x => x.Product)
                                         .Select(x => new GetProductResponse()
                                         {
                                             Name = x.Product.Name,
                                             Model = x.Product.Model,
                                             Brand = x.Product.Brand,
                                             ProductId = x.Product.ProductId,
                                             ProductDetails = x.Product.ProductDetails
                                                             .Select(y => new GetProductDetailResponse()
                                                             {
                                                                 Color = y.Color,
                                                                 Count = y.Count,
                                                                 Detail = y.Detail,
                                                                 MerchantName = y.Merchant.MerchantName,
                                                                 Price = y.Price,
                                                                 Size = y.Size
                                                             }).ToList(),
                                         }
                                         ).ToList();

            var userCartResponse = new GetUserCartResponse()
            {
                CartId = cart.CartId
            };

            if(products.Count > 0)
            {
                userCartResponse.Products.AddRange(products);
            }

            return userCartResponse;
        }
    }
}
