using Microsoft.AspNetCore.Mvc;
using Mobiliva.Mulakat.Business.Abstract;
using Mobiliva.Mulakat.Core.Enums;
using Mobiliva.Mulakat.Entities.Concrete;
using Mobiliva.Mulakat.Entities.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpPost]
		public IActionResult Add(CreateOrderRequestDto input)
		{
			var result = _orderService.Add(input);

			if (result.Status != Status.Success)
				return BadRequest(result);

			return Ok(result);
		}
	}
}
