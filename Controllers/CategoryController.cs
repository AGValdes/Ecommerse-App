using Ecommerce_App.Models;
using Ecommerce_App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategory _category;
		public CategoryController(ICategory category)
		{
			_category = category;
		}

		public IActionResult Index()
		{
			return View();
		}
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
      return Ok(await _category.GetCategories());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int Id)
    {
      Category category = await _category.GetCategory(Id);

      if (category == null)
      {
        return NotFound();
      }

      return category;
    }
  
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoom(Category category)
    {

      var updatedCategory = await _category.UpdateCategory(category);
      return Ok(updatedCategory);
    }

  
    [HttpPost]
    public async Task<ActionResult<Category>> PostRoom(Category category)
    {
      await _category.CreateCategory(category);
      return CreatedAtAction("GetCategory", new { id = category.Id }, category);

    }


   
    [HttpDelete("{id}")]
    public async Task<ActionResult<Category>> DeleteCategory(int id)
    {
      await _category.DeleteCategory(id);
      return NoContent();
    }

 
    [HttpPost]
    [Route("{categoryId}/{productId}")]
    public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
    {
      await _category.AddProductToCategory(roomId, amenityId);
      return NoContent();
    }
    

  }
}
