using AutoMapper;
using ShopEasyApi.Dtos.AuthDtos;
using ShopEasyApi.Entities;

namespace ShopEasyApi.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UserRegisterRequestDto, AppUser>();
            CreateMap<AppUser, UserDto>();
        }
    }
}
