namespace Entities.Dto.RequestDto.CategoryRequestDto
{
    public class AddCategoryRequest
    {
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
