using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Stopify.Model;
using Stopify.Service.Services.Interfaces;

namespace Stopify.Artist.API.Controllers
{
    [Route("api/[controller]/v1/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IMemoryCache memoryCache;
        public readonly IArtistService artistService;
        public LoginController(IMemoryCache _memoryCache, IArtistService _artistService)
        {
            memoryCache = _memoryCache;
            artistService = _artistService;
        }

        [HttpPost]
        public General<bool> Login([FromBody] Model.Dtos.LoginDto loginArtist) 
        {
            General<bool> response = new() { Entity = false };
            General<Model.Dtos.ArtistDto> _response = artistService.Login(loginArtist);
            if (_response.IsSuccess)
            {
                if (!memoryCache.TryGetValue($"Login:{_response.Entity.Id}", out Model.Dtos.ArtistDto _loginUser))
                {
                    memoryCache.Set($"Login:{_response.Entity.Id}", response.Entity);
                }
                response.Entity = true;
            }
            return response;
        }
    }
}
