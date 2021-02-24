using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Models
{
	public class CartProduct
	{

		public int ProductId { get; set; }
		public int CartId { get; set; }
		
		public int Quantity { get; set; }

		public Product Product { get; set; }
		public Cart Cart { get; set; }
	}
}
