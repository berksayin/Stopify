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
    [Route("api/[controller]/v1/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(string userName, string password)
        {
            return Ok(_userService.Login(userName, password));
        }

        [HttpGet("getActiveUsers")]
        public General<Model.Dtos.UserDetailsDto> GetActiveUsers()
        {
            return _userService.GetActiveUsers();
        }

        [HttpPost("activateUser")]
        public IActionResult ActivateUser(string userName, string password)
        {
            return Ok(_userService.ActivateUser(userName, password));
        }
        [HttpPost("insert")]
        public General<Model.Dtos.UserDto> Insert([FromBody] Stopify.Model.Dtos.UserDto newUser)
        {
            return _userService.Insert(newUser);
        }

        [HttpPut("update")]
        public General<Model.Dtos.UserUpdateDto> Update([FromBody] Stopify.Model.Dtos.UserUpdateDto updateUser)
        {
            return _userService.Update(updateUser);
        }

        [HttpPut("delete")]
        public General<Model.Dtos.UserDeleteDto> Delete([FromBody] Stopify.Model.Dtos.UserDeleteDto deleteUser, int id)
        {
            return _userService.Delete(deleteUser, id);
        }
    }
}
