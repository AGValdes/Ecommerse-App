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
	public class CategoryRepository : ICategory
	{
    public EcommerceDBContext _context;
    public CategoryRepository(EcommerceDBContext context)
    {
      _context = context;
    }


		public async Task<Category> CreateCategory(Category category)
		{
			_context.Entry(category).State = EntityState.Added;
			await _context.SaveChangesAsync();
			return category;
		}
		public async Task<List<Category>> GetCategories()
		{
			var categories = await _context.categories.ToListAsync();
			return categories;
		}

		public async Task<CategoryDetailsDTO> GetCategory(int Id)
		{

			var category = await _context.categories.Include(category => category.Products).ThenInclude(products => products.product).ToListAsync();
			return category
				.Select(Category => new CategoryDetailsDTO
				{
					Id = Category.Id,
					Name = Category.Name,
					Description = Category.Description,
					Products = Category.Products
					.Select(p => new ProductDTO()
					{
						Id = p.product.Id,
						Name = p.product.Name,
						Description = p.product.Description,
						ImgUrl = p.product.ImgUrl,
						Price = p.product.Price
					}).ToList()
				}).FirstOrDefault(c => c.Id == Id);
		}

		public async Task<Category> UpdateCategory(Category category)
		{
			_context.Entry(category).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return category;
		}
		public async Task DeleteCategory(int Id)
		{
			var category = await GetCategory(Id);
			_context.Entry(category).State = EntityState.Deleted;
			await _context.SaveChangesAsync();
		}
		public async Task AddProductToCategory(int categoryId, int productId)
		{
			CategoryProduct product = new CategoryProduct()
			{
				CategoryId = categoryId,
				ProductId = productId
			};
			_context.Entry(product).State = EntityState.Added;
			await _context.SaveChangesAsync();
		}
	}
}
