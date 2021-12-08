using AutoMapper;

namespace Stopify.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Stopify.Model.Dtos.UserDto, Stopify.DB.Entities.User>();
            CreateMap<Stopify.DB.Entities.User, Stopify.Model.Dtos.UserDto>();
        }
    }
}
