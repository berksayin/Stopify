using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stopify.Service.Services.Interfaces;

namespace Stopify.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login(string userName, string password)
        {
            return Ok(_userService.Login(userName, password));
        }
    }
}
