using System.Linq;
using AutoMapper;
using DatingApp.Api.DTOs;
using DatingApp.Api.Models;

namespace DatingApp.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDetailDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsProfilePhoto).URL);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom((src, dest) => src.DateOfBirth.CalculateAge());
                });

            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>{
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsProfilePhoto).URL);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom((src, dest) => src.DateOfBirth.CalculateAge());
                });

            CreateMap<Photo, PhotoForDetailDto>();

            CreateMap<City, CityDto>();

            CreateMap<Country, CountryDto>();

            CreateMap<Gender, GenderDto>();

            CreateMap<UserForUpdateDto, User>();
            CreateMap<CityDto, City>();
            CreateMap<CountryDto, Country>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();

            CreateMap<UserForRegisterDto, User>();
        }
    }
}