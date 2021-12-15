using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Stopify.Artist.API.Infrastructure;
using Stopify.Model;
using Stopify.Service.Services.Interfaces;

namespace Stopify.Artist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : BaseController
    {
        private readonly IArtistService artistService;
        private readonly IMapper mapper;
        public ArtistController(IArtistService _artistService, IMapper _mapper)
        {
            artistService = _artistService;
            mapper = _mapper;
        }

        //29:00

        //[HttpPost]
        //public General<Model.Dtos.ArtistDto> Insert([FromBody] Stopify.Model.Dtos.ArtistDto newArtist)
        //{
        //    if (CurrentArtist is not null)
        //    {

        //    }
        //    General<Model.Dtos.ArtistDto> response = new General<Model.Dtos.ArtistDto>();
        //    var result = false;
        //    return artistService.Insert(newArtist);
        //}
    }
}
