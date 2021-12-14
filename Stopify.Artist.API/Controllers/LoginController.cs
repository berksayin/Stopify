using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Stopify.Model;

namespace Stopify.Artist.API.Controllers
{
    [Route("api/[controller]/v1/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IMemoryCache memorycahe;
        public readonly IMapper mapper;
        public LoginController(IMemoryCache _memorycahe, IMapper _mapper)
        {
            memorycahe = _memorycahe;
            mapper = _mapper;
        }

        [HttpPost]
        public General<bool> Login([FromBody] Model.Dtos.LoginDto loginUser) 
        {
            General<bool> response = new();
            return response;
        }
    }
}
