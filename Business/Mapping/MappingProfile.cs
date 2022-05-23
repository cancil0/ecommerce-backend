using AutoMapper;
using Entities.Concrete;
using Entities.Dto.RequestDto.AddressRequestDto;
using Entities.Dto.RequestDto.CarouselRequestDto;
using Entities.Dto.RequestDto.CategoryRequestDto;
using Entities.Dto.RequestDto.MediaRequestDto;
using Entities.Dto.RequestDto.MerchantRequestDto;
using Entities.Dto.RequestDto.ProductDetailRequestDto;
using Entities.Dto.RequestDto.ProductRequestDto;
using Entities.Dto.RequestDto.RoleRequestDto;
using Entities.Dto.RequestDto.UserRequestDto;
using Entities.Dto.ResponseDto.AddressResponseDto;
using Entities.Dto.ResponseDto.CartResponseDto;
using Entities.Dto.ResponseDto.CategoryResponseDto;
using Entities.Dto.ResponseDto.MerchantResponseDto;
using Entities.Dto.ResponseDto.ProductDetailResponseDto;
using Entities.Dto.ResponseDto.ProductResponseDto;
using Entities.Dto.ResponseDto.UserResponseDto;
using Entities.Dto.ResponseDto.UserRoleResponseDto;

namespace Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //UserMappings
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<User, GetUserResponse>().ForMember(x => x.UserRoles, opt => opt.Ignore());
            CreateMap<GetUserDefaultRequest, UserDefault>();
            CreateMap<UserDefault, GetUserDefaultResponse>();
            CreateMap<CreateUserDefaultRequest, UserDefault>();

            //AddressMappings
            CreateMap<CreateAddressRequest, Address>();
            CreateMap<Address, GetUserAddressResponse>();

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

            //CartMappings
            CreateMap<Cart, GetUserCartResponse>();

            //CarouselMappings
            CreateMap<AddCarouselRequest, Carousel>();
        }
    }
}
