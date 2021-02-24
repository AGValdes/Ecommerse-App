using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_App.Auth.Models.DTO;
using Ecommerce_App.Auth.Services.Interfaces;
using Ecommerce_App.Models;
using Ecommerce_App.Models.DTO;
using Ecommerce_App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Ecommerce_App.Pages
{
    public class CatDetailsModel : PageModel
    {
        [BindProperty]
        public CategoryDetailsDTO CategoryInfo { get; set; }
        public UserCart UserCart { get; set; }
   

        private readonly IConfiguration _config;
        private readonly ICategory _category;
        private readonly IProduct _product;
        private readonly ICart _cart;
        private readonly IUserService _user;

        public CatDetailsModel(IConfiguration config, ICategory category, IProduct product, ICart cart, IUserService user)
        {
            _config = config;
            _category = category;
            _product = product;
            _cart = cart;
            _user = user;
        }

        public async Task<IActionResult> OnGet(int id)
        {
      
            UserDTO user = await _user.GetUser(User);
            UserCart = user.Cart;
            CategoryInfo = await _category.GetCategory(id);
            return Page();
        }

        public async Task<IActionResult> OnPost(int productId, int cartId)
        {
          await _cart.AddProductToCart(productId, cartId);
          return RedirectToPage("Cart");
		    }
    }
}
