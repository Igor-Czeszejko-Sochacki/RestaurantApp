using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using restaurant_app_backend.DbModels.Request;
using restaurant_app_backend.DbModels.Response;
using restaurant_app_backend.Models;
using restaurant_app_backend.Service;

namespace restaurant_app_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUserVM user)
        { 
            var result = await _accountService.Register(user);
            if (result.Response != null)
                return BadRequest(result);
            return Ok("User was added");
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM user)
        {
            var result = await _accountService.Login(user);
            if (result.Response != null)
                return BadRequest(result);
            return Ok("Logged in");
        }
    }
}
