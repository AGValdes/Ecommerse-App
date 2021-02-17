using Ecommerce_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Controllers
{
	public class DashboardController : Controller
	{

		public static List<Category> categories = new List<Category>()
			{
						new Category() {Id = 1, Name = "Weapons", Description = "Magical items used for combat" },
						new Category() { Name = "Armor", Description = "Magical items used for armor" },
						new Category() { Name = "Potions", Description = "Magical concoctions" },
						new Category() { Name = "Rings", Description = "Magical Jewelry" },
						new Category() { Name = "Rods", Description = "Rods imbued with magical properties" },
						new Category() { Name = "Scrolls", Description = "Parchment scrolls with magical encryptions" },
						new Category() { Name = "Staves", Description = "Staves imbued with magical properties" },
						new Category() { Name = "Wands", Description = "Magical implements with pre-set spells" },
						new Category() { Name = "Wonderous Items", Description = "Miscellaneous Magical Item" }
			};
		Product sunBlade = new Product() { Id = 1, Name = "Sun Blade", Description = "This appears to be a long sword hilt, but it emenates a radiant energy", Category = categories[0], Price = 100.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/436/1000/1000/636284772783859015.jpeg" };
		
		[Authorize(Roles = "Admin")]
		public IActionResult Index()
		{
			return View(categories);
		} 

		[Authorize(Roles = "Admin")]
		public IActionResult CategoryDetails()
		{

			return View();
		
		}

		[Authorize(Roles = "Admin")]
		public IActionResult ProductDetails()
		{

			return View();

		}
	}
	
}



