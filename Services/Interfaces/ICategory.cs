﻿using Ecommerce_App.Models;
using Ecommerce_App.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Services.Interfaces
{
	public interface ICategory
	{

		Task<Category> CreateCategory(Category category);
		Task<CategoryDetailsDTO> GetCategory(int Id);
		Task<List<Category>> GetCategories();
		Task<Category> UpdateCategory(Category category);
		Task DeleteCategory(int Id);
		Task AddProductToCategory(int categoryId, int productId);
	}
}
