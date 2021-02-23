using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Ecommerce_App.Models;
using Ecommerce_App.Models.DTO;
using Ecommerce_App.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
		private readonly IConfiguration _configuration;
		public DashboardController(IProduct product, ICategory category, IConfiguration configuration)
		{
			_product = product;
			_category = category;
			_configuration = configuration;
		}

		//<------------------------PAGE DISPLAY------------------------>

		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<List<Category>>> Admin()
		{
			var categories = await _category.GetCategories();
			return View(categories);
		}

		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<Category>> CategoryDetails(int id)
		{
			var catagory = await _category.GetCategory(id);
			return View(catagory);

		}

		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<ProductDetailsDTO>> ProductDetails(int id)
		{

			return View();
        }

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> PutProduct()
        {
			return Redirect("/dashboard/productdetails");
        }


		//<------------------------CUD OPERATIONS------------------------>

		//CREATE
		[HttpPost]
		public async Task<ActionResult<Product>> PostProduct(Product product)
		{
			await _product.CreateProduct(product);
			return CreatedAtAction("Getproduct", new { id = product.Id }, product);

		}

		[HttpPost]
		public async Task<ActionResult<Category>> PostCategory(Category category)
		{
			await _category.CreateCategory(category);
			return CreatedAtAction("GetCategory", new { id = category.Id }, category);

		}

		[HttpPost]
		[Route("{categoryId}/{productId}")]
		public async Task<IActionResult> AddProductToCategory(int roomId, int amenityId)
		{
			await _category.AddProductToCategory(roomId, amenityId);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<Document>> UploadImage(IFormFile file)
        {
			BlobContainerClient container = new BlobContainerClient(_configuration.GetConnectionString("StorageAccount"), "images");
			await container.CreateIfNotExistsAsync();
			BlobClient blob = container.GetBlobClient(file.FileName);
			using var stream = file.OpenReadStream();
			BlobUploadOptions options = new BlobUploadOptions()
			{
				HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
			};
            if (!blob.Exists())
            {
				await blob.UploadAsync(stream, options);
            }
			Document document = new Document() 
			{ 
				Name = file.FileName, 
				Type = file.ContentType, 
				Size = file.Length, 
				URL = blob.Uri.ToString() 
			};
			return View(document);
        }


		//UPDATE
		[HttpPut()]
		public async Task<IActionResult> PutProduct(Product product)
		{

			var updatedproduct = await _product.UpdateProduct(product);
			return Redirect("/Dashboard/Productdetails");
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutCategory(Category category)
		{

			var updatedCategory = await _category.UpdateCategory(category);
			return Ok(updatedCategory);
		}


		//DELETE
		[HttpDelete("{id}")]
		public async Task<ActionResult<Product>> DeleteProduct(int id)
		{
			await _product.DeleteProduct(id);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Category>> DeleteCategory(int id)
		{
			await _category.DeleteCategory(id);
			return NoContent();
		}

	}
}



