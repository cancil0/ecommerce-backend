namespace Entities.Dto.RequestDto.ProductDetailRequestDto
{
    public class AddProductDetailRequest
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string Detail { get; set; }
        public string Color { get; set; }
        public int? Size { get; set; }
        public Guid ProductId { get; set; }
        public Guid MerchantId { get; set; }
    }
}
