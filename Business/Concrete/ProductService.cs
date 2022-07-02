using AutoMapper;
using Business.Abstract;
using Core.Concrete;
using Core.ExceptionHandler;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.ProductRequestDto;
using Entities.Dto.ResponseDto.ProductResponseDto;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly ICategoryDal categoryDal;
        private readonly IProductDal productDal;
        private readonly IMapper mapper;
        
        public ProductService(ICategoryDal categoryDal, 
                              IProductDal productDal, 
                              IMapper mapper)
        {
            this.categoryDal = categoryDal;
            this.productDal = productDal;
            this.mapper = mapper;
        }

        public void AddProduct(AddProductRequest addProduct)
        {
            var category = categoryDal.Get(x=> x.CategoryId == addProduct.CategoryId);

            if(category is null)
            {
                throw new AppException("Category.NotFound", ExceptionTypes.NotFound.GetValue());
            }

            Product product = mapper.Map<Product>(addProduct);
            product.Category = category;

            var coverPhotoCount = product.Medias.Count(x => x.IsCoverPhoto);

            if(coverPhotoCount > 1)
            {
                foreach (var media in product.Medias)
                {
                    if (coverPhotoCount > 1 && media.IsCoverPhoto)
                    {
                        coverPhotoCount--;
                        media.IsCoverPhoto = false;
                    }
                }
            }

            productDal.Insert(product);
        }

        public void DeleteProduct(DeleteProductRequest deleteProduct)
        {
            var product = productDal.Get(x => x.ProductId == deleteProduct.ProductId || x.Name == deleteProduct.Name);

            if (product is null)
            {
                throw new AppException("Product.NotFound", ExceptionTypes.NotFound.GetValue());
            }

            productDal.Delete(product);
        }

        public GetProductResponse GetProduct(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                throw new AppException("Product.EnterProductId", ExceptionTypes.BadRequest.GetValue());
            }

            var product = productDal.Get(x => x.ProductId == productId, 
                                         x => x.Include(x => x.ProductDetails)
                                               .Include(x => x.Medias)
                                               .Include(x => x.Category));

            if (product is null)
            {
                throw new AppException("Product.NotFound", ExceptionTypes.NotFound.GetValue());
            }

            return mapper.Map<GetProductResponse>(product);
        }

        public List<GetProductResponse> GetCategoryProducts(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new AppException("Product.EnterProductId", ExceptionTypes.BadRequest.GetValue());
            }

            var products = productDal.GetMany(x => x.Category.CategoryId == categoryId, x => x.ProductDetails, x => x.Medias, x => x.Category);

            var response = new List<GetProductResponse>();

            foreach (var product in products)
            {
                response.Add(mapper.Map<GetProductResponse>(product));
            }

            return response;
        }

        public void UpdateProduct(UpdateProductRequest updateProduct)
        {
            var product = productDal.GetById(updateProduct.ProductId);

            if (product is null)
            {
                throw new AppException("Product.NotFound", ExceptionTypes.NotFound.GetValue());
            }

            mapper.Map(updateProduct, product);

            var category = categoryDal.Get(x => x.CategoryId == updateProduct.CategoryId);

            if (category is null)
            {
                throw new AppException("Category.NotFound", ExceptionTypes.NotFound.GetValue());
            }

            var isCoverPhoto = product.Medias.Count(x => x.IsCoverPhoto);

            if (isCoverPhoto > 1)
            {
                foreach (var media in product.Medias)
                {
                    if (isCoverPhoto > 1 && media.IsCoverPhoto)
                    {
                        isCoverPhoto--;
                        media.IsCoverPhoto = false;
                    }
                }
            }

            productDal.Update(product);
        }
    }
}
