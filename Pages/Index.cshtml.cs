using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_App.Models;
using Ecommerce_App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Ecommerce_App.Pages
{
    public class IndexModel : PageModel
    {
        public List<Category> categories { get; set; }

        private readonly IConfiguration _config;
        private readonly ICategory _category;
        private readonly IProduct _product;

        public IndexModel(IConfiguration config, ICategory category, IProduct product)
        {
            _config = config;
            _category = category;
            _product = product;
        }

        public async Task OnGet()
        {
            categories = await _category.GetCategories();
        }
    }
}
