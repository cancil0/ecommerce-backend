namespace Entities.Dto.RequestDto.ProductDetailRequestDto
{
    public class GetProductDetailRequest
    {
        public Guid ProductId { get; set; }
        public Guid? MerchantId { get; set; }
    }
}
