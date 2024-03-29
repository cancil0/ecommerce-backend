﻿using AutoMapper;
using Business.Abstract;
using Core.Attributes;
using Core.Concrete;
using Core.ExceptionHandler;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.CategoryRequestDto;
using Entities.Dto.ResponseDto.CategoryResponseDto;
using Entities.Enums;
using Microsoft.Extensions.Caching.Memory;

namespace Business.Concrete
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        private readonly IMapper mapper;
        private readonly IMemoryCache cache;
        public CategoryService(ICategoryDal categoryDal, 
                               IMapper mapper, 
                               IMemoryCache cache)
        {
            this.categoryDal = categoryDal;
            this.mapper = mapper;
            this.cache = cache;
        }

        public GetCategoryResponse GetCategory(Guid categoryId)
        {
            if (cache.TryGetValue(CacheTypes.CategoryResponse.GetValue(), out List<GetCategoryResponse> categoryResponse))
            {
                return categoryResponse.FirstOrDefault(x => x.CategoryId == categoryId);
            }
            var category = categoryDal.GetById(categoryId);
            categoryResponse = new List<GetCategoryResponse>
            {
                new GetCategoryResponse()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    ParentCategoryId = category.ParentCategoryId
                }
            };

            return categoryResponse.FirstOrDefault();
        }

        public List<GetCategoryResponse> GetCategories()
        {
            if(cache.TryGetValue(CacheTypes.CategoryResponse.GetValue(), out List<GetCategoryResponse> categoryResponse))
            {
                return categoryResponse;
            }

            categoryResponse = new List<GetCategoryResponse>();

            var categories = categoryDal.GetAll();

            foreach (var category in categories)
            {
                categoryResponse.Add(new GetCategoryResponse()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    ParentCategoryId = category.ParentCategoryId
                });
            }
            cache.Set(CacheTypes.CategoryResponse.GetValue(), categoryResponse);
            return categoryResponse;
        }

        [UnitofWork]
        public void AddCategory(AddCategoryRequest addCategory)
        {
            CategoryValidation(new CategoryValidationRequest()
            {
                Name = addCategory.Name,
                ParentCategoryId = addCategory.ParentCategoryId
            });

            var category = mapper.Map<Category>(addCategory);
            categoryDal.Insert(category);
            cache.Remove(CacheTypes.CategoryResponse.GetValue());
        }

        [UnitofWork]
        public void DeleteCategory(DeleteCategoryRequest deleteCategory)
        {
            if (deleteCategory.CategoryId is null && string.IsNullOrEmpty(deleteCategory.CategoryName))
            {
                throw new AppException("Category.EnterCategoryName", ExceptionTypes.NotAllowed.GetValue());
            }
            var category = categoryDal.Get(x => x.CategoryId == deleteCategory.CategoryId || x.Name == deleteCategory.CategoryName);

            if(category is null)
            {
                throw new AppException("Category.NotFound", ExceptionTypes.NotFound.GetValue());
            }

            categoryDal.Delete(category);
            cache.Remove(CacheTypes.CategoryResponse.GetValue());
        }

        [UnitofWork]
        public void UpdateCategory(UpdateCategoryRequest updateCategory)
        {
            CategoryValidation(new CategoryValidationRequest()
            {
                Name = updateCategory.Name,
                ParentCategoryId = updateCategory.ParentCategoryId
            });

            var category = categoryDal.Get(x => x.CategoryId == updateCategory.CategoryId);
            mapper.Map(updateCategory, category);
            categoryDal.Update(category);
            cache.Remove(CacheTypes.CategoryResponse.GetValue());
        }

        public List<GetCategoryResponse> GetSubCategories(Guid categoryId)
        {
            var categoryResponse = new List<GetCategoryResponse>();

            var categories = categoryDal.GetMany(x => x.ParentCategoryId == categoryId);

            foreach (var category in categories)
            {
                categoryResponse.Add(new GetCategoryResponse()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    ParentCategoryId = category.ParentCategoryId
                });

            }
            return categoryResponse;
        }
        private void CategoryValidation(CategoryValidationRequest categoryValidation)
        {
            if (string.IsNullOrEmpty(categoryValidation.Name))
            {
                throw new AppException("Category.EnterCategoryName", ExceptionTypes.NotAllowed.GetValue());
            }
            else
            {
                var categoryName = categoryDal.Get(x => x.Name == categoryValidation.Name, null, true)?.Name;
                if (!string.IsNullOrEmpty(categoryName))
                {
                    throw new AppException("Category.AlreadyAdded", ExceptionTypes.BadRequest.GetValue(), categoryName);
                }
            }

            if (categoryValidation.ParentCategoryId is not null)
            {
                var parentCategory = categoryDal.Get(x => x.CategoryId == (Guid)categoryValidation.ParentCategoryId, null, true);

                if (parentCategory is null)
                {
                    throw new AppException("Category.ParentCategoryNotFound", ExceptionTypes.NotFound.GetValue());
                }
            }
        }

    }
}
