using OrderCards.DAL.Abstractions;
using OrderCards.Domain.OrderModels;
using OrderCards.Services.Abstractions;

namespace OrderCards.Services.Implementations
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepo;

		public OrderService(IOrderRepository orderRepo)
		{
			_orderRepo = orderRepo;
		}

		public async Task<ICollection<OrderResponseModel>> GetAllAsync()
		{
			var orders = await _orderRepo.GetAllAsync();

			var orderResponseModels = orders.Select(x => new OrderResponseModel()
			{ 
				OrderId = x.OrderId,
				DeliveryDate = x.DeliveryDate, 
				Address = x.Address, 
				PhoneNumber = x.PhoneNumber
			}).ToList();

			return orderResponseModels;
		}

		public async Task<OrderResponseModel> GetByIdAsync(int id)
		{
			var order = await _orderRepo.GetByIdAsync(id);

			var orderResponseModel = new OrderResponseModel()
			{
				OrderId = order.OrderId,
				OrderDate = order.OrderDate,
				DeliveryDate = order.DeliveryDate,
				Address = order.Address,
				PhoneNumber = order.PhoneNumber
			};

			return orderResponseModel;
		}

		public async Task<Order> CreateAsync(CreateOrderRequest request)
		{
			Order order = new()
			{
				OrderDate = request.OrderDate,
				DeliveryDate = request.DeliveryDate,
				Address = request.Address,
				PhoneNumber = request.PhoneNumber
			};

			await _orderRepo.CreateAsync(order);

			return order;
		}

		public async Task<Order> UpdateAsync(int id, UpdateOrderRequest request)
		{
			request.OrderId = id;

			var orderInDb = await _orderRepo.GetByIdAsync(request.OrderId);

			if (orderInDb == null)
			{
				return null;
			}

			Order order = new()
			{
				OrderId = request.OrderId,
				OrderDate = request.OrderDate,
				DeliveryDate = request.DeliveryDate,
				Address = request.Address,
				PhoneNumber = request.PhoneNumber
			};

			await _orderRepo.UpdateAsync(order);

			return order;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var order = await _orderRepo.GetByIdAsync(id);

			if (order == null)
			{
				return false;
			}

			await _orderRepo.DeleteAsync(order);

			return true;
		}
	}
}
