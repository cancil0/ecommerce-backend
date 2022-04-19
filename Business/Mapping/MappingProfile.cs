using AutoMapper;
using Entities.Concrete;
using Entities.Dto.RequestDto.AddressRequestDto;
using Entities.Dto.RequestDto.CategoryRequestDto;
using Entities.Dto.RequestDto.MediaRequestDto;
using Entities.Dto.RequestDto.MerchantRequestDto;
using Entities.Dto.RequestDto.ProductDetailRequestDto;
using Entities.Dto.RequestDto.ProductRequestDto;
using Entities.Dto.RequestDto.RoleRequestDto;
using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Dto.ResponseDto.CategoryResponseDto;
using Entities.Dto.ResponseDto.MerchantResponseDto;
using Entities.Dto.ResponseDto.ProductDetailResponseDto;
using Entities.Dto.ResponseDto.ProductResponseDto;

namespace Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CustomerMappings
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();

            //AddressMappings
            CreateMap<CreateAddressRequest, Address>();

            //RoleMappings
            CreateMap<CreateRoleRequest, Role>();

            //ProductMappings
            CreateMap<AddProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, GetProductResponse>();

            //ProductDetailMapping
            CreateMap<AddProductDetailRequest, ProductDetail>();
            CreateMap<UpdateProductDetailRequest, ProductDetail>();
            CreateMap<ProductDetail, GetProductDetailResponse>();

            //MediaMappings
            CreateMap<AddMediaRequest, Media>();

            //CategoryMappings
            CreateMap<AddCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<Category, GetCategoryResponse>();

            //MerchantMappings
            CreateMap<AddMerchantRequest, Merchant>();
            CreateMap<UpdateMerchantRequest, Merchant>();
            CreateMap<Merchant, GetMerchantResponse>();
        }
    }
}
