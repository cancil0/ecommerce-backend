using Entities.Dto.RequestDto.MediaRequestDto;

namespace Entities.Dto.RequestDto.ProductRequestDto
{
    public class AddProductRequest
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Guid CategoryId { get; set; }
        public List<AddMediaRequest> Medias { get; set; }
    }
}
