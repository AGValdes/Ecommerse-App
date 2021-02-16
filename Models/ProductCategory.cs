using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Models
{
	public class ProductCategory
	{
		public int ProductId { get; set; }
		public int CategoryId { get; set; }


		public ProductCategory(Category category, Product product)
		{
			ProductId = product.Id;
			CategoryId = category.Id;
		}
	}
}
