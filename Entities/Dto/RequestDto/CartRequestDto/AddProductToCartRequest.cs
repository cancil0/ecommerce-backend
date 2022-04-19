namespace Entities.Dto.RequestDto.CartRequestDto
{
    public class AddProductToCartRequest
    {
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
    }
}
