using Ecommerce_App.Auth.Models.DTO;
using Ecommerce_App.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Controllers
{
    public class LoginController : Controller
    {
        private IUserService userService;
        // IUserService is "given to us" by DI


        public LoginController(IUserService service)
        {
            userService = service;
        }


        // This should be the login screen
        public IActionResult Index()
        {
            return View();
        }


        // Register Screen
        public IActionResult Register()
        {
            return View();
        }


        // Error Screen
        public IActionResult Error()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult<UserDTO>> Authenticate(LoginData data)
        {
            var user = await userService.Authenticate(data.Username, data.Password);
            if (user == null)
            {
                return Redirect("/login");
            }
            return Redirect("/login/welcome");
        }


        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register(RegisterUser data)
        {
           if(ModelState.IsValid)
           {
                var user = await userService.Register(data, this.ModelState);
           
                return Redirect("/login");

			      }
            else
            {
                 ModelState.AddModelError(string.Empty, "Invalid Username or Password");
                 return View(data);
			      }
       
        }



    public IActionResult Welcome()
        {
            return View();
        }



        [Authorize(Policy = "read")]
        public async Task<ActionResult<UserDTO>> Profile()
        {
            UserDTO user = await userService.GetUser(this.User);
            return View(user);
        }
    }
}
