using Ecommerce_App.Models;
using Ecommerce_App.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Services.Interfaces
{
	public interface ICart
	{
		public Task<List<ProductDTO>> GetCart(int id);
		public Task<Cart> CreateBlankCart();
		public Task AddProductToCart(int productId, int cartId);
		public Task DeleteProductFromCart(int id);
	}
}
