using Entities.Dto.ResponseDto.ProductResponseDto;

namespace Entities.Dto.ResponseDto.CartResponseDto
{
    public class GetUserCartResponse
    {
        public Guid CartId { get; set; }

        public List<GetProductResponse> Products { get; set; }
    }
}
