using Ecommerce_App.Auth.Models;
using Ecommerce_App.Auth.Models.DTO;
using Ecommerce_App.Auth.Services.Interfaces;
using Ecommerce_App.Data;
using Ecommerce_App.Models;
using Ecommerce_App.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ecommerce_App.Auth.Services
{
    public class IdentityUserService : IUserService
    {
        private UserManager<AuthUser> userManager;
        private SignInManager<AuthUser> signInManager;
        private EcommerceDBContext _context;
        private ICart _cart;
        public IdentityUserService(UserManager<AuthUser> manager, SignInManager<AuthUser> sim, EcommerceDBContext context, ICart cart)
        {
            userManager = manager;
            signInManager = sim;
            _context = context;
             _cart = cart;
        }
        public async Task<UserDTO> Register(RegisterUser data, ModelStateDictionary modelState)
        {
            // throw new NotImplementedException();
            var user = new AuthUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
               
             };
     
            var result = await userManager.CreateAsync(user, data.Password);
            if (result.Succeeded)
            {
                 
                // Because we have a "Good" user, let's add them to their proper role
                List<string> roles = new List<string> { "guest" };
                await userManager.AddToRolesAsync(user, roles);
                var cart = await GiveUserACart(user.Id);
                 return new UserDTO
                {
                    ID = user.Id,
                    Username = user.UserName,
                    Roles = roles,
                    Cart = cart
                };
            }
           
      // What about our errors?
      foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }
            
            return null;
        }
        private TimeSpan TimeSpan(object p)
        {
            throw new NotImplementedException();
        }
        public async Task<UserDTO> Authenticate(string username, string password)
        {
            var result = await signInManager.PasswordSignInAsync(username, password, true, false);
            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(username);
                return new UserDTO
                {
                    ID = user.Id,
                    Username = user.UserName,
                    Roles = await userManager.GetRolesAsync(user)
                };
            }
            return null;
        }
        // Use a "claim" to get a user
        public async Task<UserDTO> GetUser(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            if(user != null)
            {
                return new UserDTO
                {
                    ID = user.Id,
                    Username = user.UserName,
                    Roles = await userManager.GetRolesAsync(user)
                };
            }
            return null;
        }

        public async Task<Cart> GiveUserACart(string userId)
        {
             Cart newCart = await _cart.CreateBlankCart(userId);
            return newCart;

		    }
    }
}
