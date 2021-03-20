using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using restaurant_app_backend.DbModels.Request;
using restaurant_app_backend.Models;

namespace restaurant_app_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        //public async Task<IActionResult> Register(UserModel userModel)
        //{
        //    var text = new ResultDTO()
        //    {
        //        Response = null
        //    };
        //    if(ModelState.IsValid)
        //    {
        //        var user = new UserModel { UserName = userModel.Email, Email = userModel.Email };
        //        var result = await _userManager.CreateAsync(user, userModel.PasswordHash);

        //        if (result.Succeeded)
        //        {
        //           await _signInManager.SignInAsync(user, isPersistent: false);
        //        }
        //    }

        //    return Ok(text);
        //}
    }
}
