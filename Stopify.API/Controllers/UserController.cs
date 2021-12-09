using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stopify.Model;
using Stopify.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stopify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Login(string userName, string password)
        {
            return Ok(_userService.Login(userName, password));
        }

        [HttpPost]
        public General<Model.Dtos.UserDto> Insert([FromBody] Stopify.Model.Dtos.UserDto newUser)
        {
            return _userService.Insert(newUser);
        }
    }
}
