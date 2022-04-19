namespace Entities.Dto.ResponseDto.ProductDetailResponseDto
{
    public class GetProductDetailResponse
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string Detail { get; set; }
        public string Color { get; set; }
        public int? Size { get; set; }
        public string MerchantName { get; set; }
    }
}
