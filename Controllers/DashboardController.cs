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

		
		[Authorize(Roles = "Admin")]
		public IActionResult Index()
		{
			return View();
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



