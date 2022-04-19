namespace Entities.Dto.ResponseDto.CategoryResponseDto
{
    public class GetCategoryResponse
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public Guid? ParentCategoryId { get; set; }
    }
}
