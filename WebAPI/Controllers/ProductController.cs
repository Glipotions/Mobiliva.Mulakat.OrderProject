using Microsoft.AspNetCore.Mvc;
using Mobiliva.Mulakat.Business.Abstract;
using Mobiliva.Mulakat.Core.Enums;
using Mobiliva.Mulakat.Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _productService.GetAll();
			if (result.Status==Status.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getallbycategoryname")]
		public IActionResult GetAllCategoryName(string categori)
		{
			var result = _productService.GetByCategory(categori);
			if (result.Status == Status.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _productService.GetById(id);
			if (result.Status == Status.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);

		}

		[HttpPost]
		public IActionResult Add(Product product)
		{
			var result = _productService.Add(product);

			if (result.Status != Status.Success)
				return BadRequest(result);

			return Ok(result);
		}

		[HttpPut]
		public IActionResult Update(Product product)
		{
			var result = _productService.Update(product);

			if (result.Status != Status.Success)
				return BadRequest(result);

			return Ok(result);
		}

		[HttpDelete]
		public IActionResult Delete(Product product)
		{
			var result = _productService.Delete(product);

			if (result.Status != Status.Success)
				return BadRequest(result);

			return Ok(result);
		}

	}
}
