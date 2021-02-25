using Ecommerce_App.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Models
{
	public class Cart
	{
		public int Id { get; set; }
		public string UserID { get; set; }
		public List<CartProduct> CartProducts {get; set;}

	}
}
