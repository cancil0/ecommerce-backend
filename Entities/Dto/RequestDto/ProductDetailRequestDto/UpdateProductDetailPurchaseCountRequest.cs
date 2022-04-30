namespace Entities.Dto.RequestDto.ProductDetailRequestDto
{
    public class UpdateProductDetailPurchaseCountRequest
    {
        public Guid ProductDetailId { get; set; }
        public long PurchaseCount { get; set; }
    }
}
