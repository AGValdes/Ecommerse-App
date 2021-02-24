using Ecommerce_App.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Models
{
	public class UserCart
	{

		public string UserId { get; set; }

		public int CartId { get; set; }

		public AuthUser User { get; set; }

		public Cart Cart { get; set; }
	}
}
