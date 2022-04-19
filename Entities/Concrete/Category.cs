﻿namespace Entities.Concrete
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public List<Product> Products { get; set; }
    }
}
