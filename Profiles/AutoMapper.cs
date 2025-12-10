using AutoMapper;
using ShopEasyApi.Dtos.AuthDtos;
using ShopEasyApi.Dtos.CategoryDtos;
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
        }
    }
}
