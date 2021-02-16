using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Models
{
	public class CategoryProduct
	{
		public int ProductId { get; set; }
		public int CategoryId { get; set; }


		public CategoryProduct(Category category, Product product)
		{
			ProductId = product.Id;
			CategoryId = category.Id;
		}
	}
}
