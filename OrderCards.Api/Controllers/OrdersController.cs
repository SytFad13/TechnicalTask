using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderCards.Domain.OrderModels;
using OrderCards.Services.Abstractions;

namespace OrderCards.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		[Authorize]
		public async Task<ActionResult<ICollection<Order>>> GetAll()
		{
			var orders = await _orderService.GetAllAsync();

			return Ok(orders);
		}

		[HttpGet]
		[Authorize]
		[Route("{id}")]
		public async Task<ActionResult<Order>> GetById(int id)
		{
			var order = await _orderService.GetByIdAsync(id);

			if (order == null)
			{
				return NotFound();
			}

			return Ok(order);
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult<Order>> Create(CreateOrderRequest request)
		{
			await _orderService.CreateAsync(request);

			return Ok(request);
		}

		[HttpPut]
		[Route("{id}")]
		[Authorize]
		public async Task<ActionResult<Order>> Update(int id, UpdateOrderRequest request)
		{
			request.OrderId = id;

			var result = await _orderService.UpdateAsync(id, request);

			if (result == null)
			{
				return new BadRequestObjectResult("Order not exists");
			}

			return Ok(request);
		}

		[HttpDelete]
		[Authorize]
		[Route("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var response = await _orderService.DeleteAsync(id);

			if (!response)
			{
				return StatusCode(404);
			}

			return Ok();
		}
	}
}
