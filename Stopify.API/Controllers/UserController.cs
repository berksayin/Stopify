using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public bool Insert(Stopify.Model.Dtos.UserDto newUser)
        {
            var result = false;
            var data = _mapper.Map<Stopify.DB.Entities.User>(newUser);
            _userService.Insert(data);
            return result;
        }
    }
}
