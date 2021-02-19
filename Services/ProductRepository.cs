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
	public class ProductRepository: IProduct
	{
    private EcommerceDBContext _context;
	
    public ProductRepository(EcommerceDBContext context)
    {
      _context = context;
    }

		public async Task<Product> CreateProduct(Product product)
		{
			_context.Entry(product).State = EntityState.Added;
			await _context.SaveChangesAsync();
			return product;
		}
		public async Task<ProductDetailsDTO> GetProduct(int Id)
		{
			return await _context.products
				.Select(p => new ProductDetailsDTO
				{
					ProductID = p.Id,
					ProductName = p.Name,
					ProductDescription = p.Description,
					ImgUrl = p.ImgUrl,
					ProductPrice = p.Price
				})
				.FirstOrDefaultAsync(p => p.ProductID == Id);

		}
		public async Task<List<Product>> GetProducts()
		{
			var products = await _context.products.ToListAsync();
			return products;
		}
		public async Task<Product> UpdateProduct(Product product)
		{
			Product newProduct = new Product()
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price
			};
			_context.Entry(newProduct).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return newProduct;
		}
		public async Task DeleteProduct(int Id)
		{
			ProductDetailsDTO product = await GetProduct(Id);
			_context.Entry(product).State = EntityState.Deleted;
			await _context.SaveChangesAsync();
		}
	}
}
