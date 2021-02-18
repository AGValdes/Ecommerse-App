using Ecommerce_App.Models;
using Ecommerce_App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Controllers
{
	public class ProductController : Controller
	{
    private readonly IProduct _product;
    public ProductController(IProduct product)
    {
      _product = product;
    }

    public IActionResult Index()
    {
      return View();
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
      return Ok(await _product.GetProducts());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Getproduct(int Id)
    {
      Product product = await _product.GetProduct(Id);

      if (product == null)
      {
        return NotFound();
      }

      return product;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoom(Product product)
    {

      var updatedproduct = await _product.UpdateProduct(product);
      return Ok(updatedproduct);
    }


    [HttpPost]
    public async Task<ActionResult<Product>> PostRoom(Product product)
    {
      await _product.CreateProduct(product);
      return CreatedAtAction("Getproduct", new { id = product.Id }, product);

    }



    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> Deleteproduct(int id)
    {
      await _product.DeleteProduct(id);
      return NoContent();
    }

  }
}
