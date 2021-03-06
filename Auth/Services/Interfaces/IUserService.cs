﻿using Ecommerce_App.Auth.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ecommerce_App.Auth.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> Register(RegisterUser data, ModelStateDictionary modelState);
        public Task<UserDTO> Authenticate(string username, string password);
        public Task<UserDTO> GetUser(ClaimsPrincipal user);
    }
}
