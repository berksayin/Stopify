using AutoMapper;

namespace Stopify.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Stopify.Model.Dtos.UserDto, Stopify.DB.Entities.User>();
            CreateMap<Stopify.DB.Entities.User, Stopify.Model.Dtos.UserDto>();
            CreateMap<Stopify.Model.Dtos.UserUpdateDto, Stopify.DB.Entities.User>();
            CreateMap<Stopify.DB.Entities.User, Stopify.Model.Dtos.UserUpdateDto>();
            CreateMap<Stopify.Model.Dtos.UserDetailsDto, Stopify.DB.Entities.User>();
            CreateMap<Stopify.DB.Entities.User, Stopify.Model.Dtos.UserDetailsDto>();
            CreateMap<Stopify.Model.Dtos.UserDeleteDto, Stopify.DB.Entities.User>();
            CreateMap<Stopify.DB.Entities.User, Stopify.Model.Dtos.UserDeleteDto>();
        }
    }
}
