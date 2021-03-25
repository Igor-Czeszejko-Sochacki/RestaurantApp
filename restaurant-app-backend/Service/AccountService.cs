using Microsoft.AspNetCore.Identity;
using restaurant_app_backend.DbModels.Request;
using restaurant_app_backend.IRepository;
using restaurant_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_app_backend.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
       // private readonly ILogger _logger;

        public AccountService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ResultDTO> Register(RegisterUserVM userModel)
        {
            var result = new ResultDTO()
            {
                Response = null
            };
            try
            {
                var user = new UserModel {UserName = userModel.Email, Email = userModel.Email };
                var newUser = await _userManager.CreateAsync(user, userModel.Password);        
            }
            catch (Exception e)
            {
                result.Response = e.Message;
                return result;
            }
            return result;
        }

        public async Task<ResultDTO> Login(LoginVM user)
        {
            var result = new ResultDTO()
            {
                Response = "Login or password was incorrect"
            };
            UserModel newUser = _userManager.FindByEmailAsync(user.Email).Result;
            var login = await _signInManager.PasswordSignInAsync(newUser, user.Password,user.RememberMe, lockoutOnFailure: false);
            if (login.Succeeded)
            {
                result.Response = null;
            }
            return result;
        }
    }
}
