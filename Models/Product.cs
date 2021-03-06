﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public int Quantity { get; set; }
		public string ImgUrl { get; set; }
		public decimal Price { get; set; }
		public CategoryProduct CategoryProduct { get; set; }

		public CartProduct CartProduct { get; set; }
	}
}
