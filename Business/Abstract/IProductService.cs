using Entities.Dto.RequestDto.ProductRequestDto;
using Entities.Dto.ResponseDto.ProductResponseDto;

namespace Business.Abstract
{
    public interface IProductService
    {
        void AddProduct(AddProductRequest addProduct);
        void UpdateProduct(UpdateProductRequest updateProduct);
        void DeleteProduct(DeleteProductRequest deleteProduct);
        GetProductResponse GetProduct(Guid ProductId);
    }
}
