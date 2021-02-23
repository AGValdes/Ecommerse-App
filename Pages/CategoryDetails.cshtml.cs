using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_App.Models.DTO;
using Ecommerce_App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Ecommerce_App.Pages
{
    public class CategoryDetailsModel : PageModel
    {
        
        public CategoryDetailsDTO CategoryInfo { get; set; }

        private readonly IConfiguration _config;
        private readonly ICategory _category;
        private readonly IProduct _product;

        public CategoryDetailsModel(IConfiguration config, ICategory category, IProduct product)
        {
            _config = config;
            _category = category;
            _product = product;
        }

        public async Task OnGet(int id)
        {
            CategoryInfo = await _category.GetCategory(id);
        }
    }
}
