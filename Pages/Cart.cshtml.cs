using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_App.Auth.Services.Interfaces;
using Ecommerce_App.Data;
using Ecommerce_App.Models;
using Ecommerce_App.Models.DTO;
using Ecommerce_App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_App.Pages
{
    public class CartModel : PageModel
    {
        private EcommerceDBContext _context { get; set; }
        public ICart _cart { get; set; }
        public IUserService _user { get; set; }
        public List<ProductDTO> CartProducts { get; set; }

        public CartModel(EcommerceDBContext context, ICart cart, IUserService user)
        {
            _context = context;
            _cart = cart;
            _user = user;
		}
        
        public async Task<IActionResult> OnGet(int cartId)
        {
            var user = await _user.GetUser(User);
            var cart = await _cart.GetCart(user.ID);
            var prodsIn = await _cart.GetCartProducts(cart.Id);
            List<ProductDTO> products = new List<ProductDTO>();
            foreach(var p in prodsIn)
            {
                var product = _context.products.Where(pr => pr.Id == p.ProductId).FirstOrDefault();
                products.Add(new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ImgUrl = product.ImgUrl
                });
            }
            CartProducts = products;
            return Page();
        }
    }
}
