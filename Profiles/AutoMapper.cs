using AutoMapper;
using ShopEasyApi.Dtos.AuthDtos;
using ShopEasyApi.Dtos.CategoryDtos;
using ShopEasyApi.Dtos.ProductDtos;
using ShopEasyApi.Entities;

namespace ShopEasyApi.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UserRegisterRequestDto, AppUser>();
            CreateMap<AppUser, UserDto>();


            CreateMap<CategoryCreateRequestDto, Category>();
            CreateMap<Category,  CategoryDto>();

            CreateMap<ProductCreateRequestDto, Product>()
                .ForMember(dest => dest.Category, opt => opt.Ignore());
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
