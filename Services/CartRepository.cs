using Ecommerce_App.Data;
using Ecommerce_App.Models;
using Ecommerce_App.Models.DTO;
using Ecommerce_App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Services
{
	public class CartRepository : ICart
	{

		private  EcommerceDBContext _context { get; set; }

		public CartRepository(EcommerceDBContext context)
		{
			_context = context;
		}


		public async Task<Cart> CreateBlankCart()
		{
				Cart cart = new Cart();
			 _context.Entry(cart).State = EntityState.Added;
			await _context.SaveChangesAsync();
			return cart;
		}
		public async Task<List<ProductDTO>> GetCart(int id)
		{
			var cartStuff = await _context.cartProducts.Where(cp => cp.CartId == id).ToListAsync();

			return cartStuff
				.Select(cp => new ProductDTO()
				{
					Id = cp.Product.Id,
					Name = cp.Product.Name,
					Description = cp.Product.Description,
					ImgUrl = cp.Product.ImgUrl,
					Price = cp.Product.Price
				}).ToList();
				
																	
		}

		public async Task AddProductToCart(int productId, int cartId)
		{
			CartProduct newProduct = new CartProduct()
			{
				ProductId = productId,
				CartId = cartId
			};
			_context.Entry(newProduct).State = EntityState.Added;
			 await _context.SaveChangesAsync();
		}

		public async Task DeleteProductFromCart(int id)
		{
			var product = await GetCart(id);
			_context.Entry(product).State = EntityState.Deleted;
			await _context.SaveChangesAsync();
		}

	}
}
