using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Models
{
	public class CategoryDetailVm
	{
		public static Category category { get; set; }
		public string CatName = category.Name;

		public string Description = category.Description;

		public List<ProductCategory> Products = category.Products;
	}
}
