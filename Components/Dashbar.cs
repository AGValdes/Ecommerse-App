using Ecommerce_App.Auth.Models.DTO;
using Ecommerce_App.Auth.Services.Interfaces;
using Ecommerce_App.Data;
using Ecommerce_App.Models.DTO;
using Ecommerce_App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Components
{
    [ViewComponent]
    public class DashbarViewComponent : ViewComponent
    {
        private EcommerceDBContext _context {get; set;}
        private ICart _cart { get; set; }
        private IUserService _user { get; set; }

        public DashbarViewComponent(EcommerceDBContext context, ICart cart, IUserService user)
        {
            _context = context;
            _cart = cart;
            _user = user;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Get the data (query the database for our products list
            var currentUser = await _user.GetUser((System.Security.Claims.ClaimsPrincipal)User);
            var cart = await _cart.GetCart(currentUser.ID);

            var products = await _cart.GetCartProducts(cart.Id);
            int count = 0;
            foreach(var p in products)
            {
                count++;
            }

            //creates an instance of view model and returns View with the model passed in
            ViewModel model = new ViewModel()
            {
                numProd = count,
                CartID = cart.Id
            };
            return View(model);

        }
        //creating feilds for our data
        public class ViewModel
        {
            public int numProd { get; set; }

            public int CartID { get; set; }
        }
    }
}
