using Entities.Dto.RequestDto.CartRequestDto;
using Entities.Dto.ResponseDto.CartResponseDto;

namespace Business.Abstract
{
    public interface ICartService
    {
        GetUserCartResponse GetUserCart(Guid userId);
        void AddProductToCart(AddProductToCartRequest addProduct);
        void RemoveProductFromCart(RemoveProductFromCartRequest removeProduct);
        void RemoveAllProductsFromCart(Guid cartId);
    }
}
