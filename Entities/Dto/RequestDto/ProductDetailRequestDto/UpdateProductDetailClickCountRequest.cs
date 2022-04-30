namespace Entities.Dto.RequestDto.ProductDetailRequestDto
{
    public class UpdateProductDetailClickCountRequest
    {
        public Guid ProductDetailId { get; set; }
        public long ClickCount { get; set; }
    }
}
