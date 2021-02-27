using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_App.Auth.Models.DTO;
using Ecommerce_App.Auth.Services.Interfaces;
using Ecommerce_App.Data;
using Ecommerce_App.Models;
using Ecommerce_App.Models.DTO;
using Ecommerce_App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_App.Pages
{
    public class CheckoutModel : PageModel
    {

        private EcommerceDBContext _context { get; set; }
        public ICart _cart { get; set; }
        public IUserService _user { get; set; }
        [BindProperty]
        public Order Order { get; set; }

        public CheckoutModel(EcommerceDBContext context, ICart cart, IUserService user)
        {
          _context = context;
          _cart = cart;
          _user = user;
        }
        public async Task<IActionResult> OnPost(string UserID)
        {
          
            var order = new Order();
            _context.Entry(order).State = EntityState.Added;
            await _context.SaveChangesAsync();
            var cart = await _cart.GetCart(UserID);
            cart.Order = order;
            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
             //List<ProductDTO> prodList = new List<ProductDTO>();
           //   foreach (var product in cart.CartProducts)
           //   {
           //        var theThingWeNeed =  _context.products.Where(p => p.Id == product.ProductId).FirstOrDefault();
           //           ProductDTO prod = new ProductDTO()
           //           {
           //             Id = theThingWeNeed.Id,
           //             Name = theThingWeNeed.Name,
           //             Price = theThingWeNeed.Price
           //           };
           //       prodList.Add(prod);
        			//}

             //order.Products = prodList;
             Order = order;
              
              return Page();

        
        }

        
    }
}
