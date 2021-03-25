using Microsoft.AspNetCore.Identity;
using restaurant_app_backend.DbModels.Request;
using restaurant_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_app_backend.Service
{
    public interface IAccountService
    {
        Task<ResultDTO> Register(RegisterUserVM user);
        Task<ResultDTO> Login(LoginVM user);
    }
}
