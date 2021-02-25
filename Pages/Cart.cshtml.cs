using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_App.Models;
using Ecommerce_App.Models.DTO;
using Ecommerce_App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_App.Pages
{
    public class CartModel : PageModel
    {
        public ICart _cart { get; set; }
        public List<ProductDTO> CartProducts { get; set; }

        public CartModel(ICart cart)
        {
            _cart = cart;
		}
        
        public async Task OnGet(int id)
        {
            //CartProducts = await _cart.GetCart(id);
        }
    }
}
