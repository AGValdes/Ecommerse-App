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

		//Navigation Properties:
		public Category category { get; set; }
		public Product product { get; set; }
	}
}
