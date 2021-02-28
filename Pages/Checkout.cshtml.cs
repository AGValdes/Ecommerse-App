using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_App.Auth.Models.DTO;
using Ecommerce_App.Auth.Services.Interfaces;
using Ecommerce_App.Data;
using Ecommerce_App.Models;
using Ecommerce_App.Models.DTO;
using Ecommerce_App.Services.Email.Interfaces;
using Ecommerce_App.Services.Email.Models;
using Ecommerce_App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_App.Pages
{
    public class CheckoutModel : PageModel
    {

        private EcommerceDBContext _context { get; set; }
        private ICart _cart { get; set; }
        private IUserService _user { get; set; }
        private IEmail _email { get; set; }
        [BindProperty]
        public Order Order { get; set; }

        public CheckoutModel(EcommerceDBContext context, ICart cart, IUserService user, IEmail email)
        {
          _context = context;
          _cart = cart;
          _user = user;
          _email = email;
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
            List<ProductDTO> prodList = new List<ProductDTO>();
            var cartProducts = await _cart.GetCartProducts(cart.Id);
            foreach(var prod in cartProducts)
            {
                var product = await _context.products.Where(p => p.Id == prod.ProductId).FirstOrDefaultAsync();
                ProductDTO productDTO = new ProductDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                };
                prodList.Add(productDTO);
            }
            Order = order;
            Order.Products = prodList;
            decimal total = 0;
            foreach(ProductDTO ppro in prodList)
            {
                total += ppro.Price;
            }
            Order.TotalCost = total; 
            return Page();

        
        }

        public async Task<IActionResult> OnPostCheckout(string ShippingStreet, string ShippingCity, string ShippingState, int ShippingZip)
        {
            Order.ShippingAddress = $"{ShippingStreet} {ShippingCity}, {ShippingState} {ShippingZip}";
            var user = await _user.GetUser(User);
            Message message = new Message()
            {
                To = user.Email,
                Subject = "Your Seraphina's Sundaries Order",
                Body = "Test email"
            };

           await _email.SendEmailAsync(message);

            //string status = response.WasSent.ToString();
            return RedirectToPage("/Index");
        }
    }
}
