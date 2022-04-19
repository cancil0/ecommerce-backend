namespace Entities.Dto.RequestDto.CartRequestDto
{
    public class RemoveProductFromCartRequest
    {
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
    }
}
