namespace Entities.Dto.RequestDto.MediaRequestDto
{
    public class AddMediaRequest
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsCoverPhoto { get; set; }
        public int Order { get; set; }
    }
}
