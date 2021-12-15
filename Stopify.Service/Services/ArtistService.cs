using AutoMapper;
using Stopify.DB.Entities.DataContext;
using Stopify.Model;
using Stopify.Model.Dtos;
using Stopify.Service.Services.Interfaces;
using System.Linq;

namespace Stopify.Service.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IMapper mapper;
        public ArtistService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        //public General<ArtistDto> Insert(ArtistDto newArtist)
        //{
        //    throw new System.NotImplementedException();
        //}

        public General<Model.Dtos.ArtistDto> Login(Stopify.Model.Dtos.LoginDto loginArtist)
        {
            General<Model.Dtos.ArtistDto> result = new();
            using (var srv = new StopifyContext())
            {
                var _data = srv.Artist.FirstOrDefault(a => a.UserName == loginArtist.UserName && a.Password == loginArtist.Password);
                if (_data is not null)
                {
                    result.IsSuccess = true;
                    result.Entity = mapper.Map<Stopify.Model.Dtos.ArtistDto>(_data);
                }
            }
            return result;
        }
    }
}
