using AutoMapper;

namespace Stopify.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Stopify.Model.Dtos.LoginDto, Stopify.DB.Entities.Artist>();
            CreateMap<Stopify.DB.Entities.Artist, Stopify.Model.Dtos.LoginDto>();
        }
    }
}
