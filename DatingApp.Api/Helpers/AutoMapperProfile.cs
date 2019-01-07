using AutoMapper;
using DatingApp.Api.DTOs;
using DatingApp.Api.Models;

namespace DatingApp.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDetailDto>();
            CreateMap<User, UserForListDto>();
            CreateMap<Photo, PhotoDto>();
        }
    }
}