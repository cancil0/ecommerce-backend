﻿namespace Entities.Dto.RequestDto.CategoryRequestDto
{
    public class CategoryValidationRequest
    {
        public string Name { get; set; }

        public Guid? ParentCategoryId { get; set; }
    }
}
