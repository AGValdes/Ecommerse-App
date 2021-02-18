using Ecommerce_App.Models;
using Ecommerce_App.Services.Interfaces;
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
		private readonly IProduct _product;
		private readonly ICategory _category;
		public DashboardController(IProduct product, ICategory category)
		{
			_product = product;
			_category = category;
		}

		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<IEnumerable<Category>>> Index()
		{
			var categories = await _category.GetCategories();
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



