using Entities.Dto.ResponseDto.CategoryResponseDto;
using Entities.Dto.ResponseDto.ProductDetailResponseDto;

namespace Entities.Dto.ResponseDto.ProductResponseDto
{
    public class GetProductResponse
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public GetCategoryResponse Category { get; set; }
        //public List<Media> Medias { get; set; } eklenecek
        public List<GetProductDetailResponse> ProductDetails { get; set; }
    }
}
