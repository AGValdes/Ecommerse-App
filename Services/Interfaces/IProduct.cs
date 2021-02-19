using Ecommerce_App.Models;
using Ecommerce_App.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Services.Interfaces
{
	public interface IProduct
	{
		Task<Product> CreateProduct(Product product);
		Task<ProductDetailsDTO> GetProduct(int Id);
		Task<List<Product>> GetProducts();
		Task<Product> UpdateProduct(Product product);
		Task DeleteProduct(int Id);

	}
}
