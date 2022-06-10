using OrderCards.Domain.OrderModels;

namespace OrderCards.Services.Abstractions
{
	public interface IOrderService
	{
		Task<ICollection<OrderResponseModel>> GetAllAsync();
		Task<Order> GetByIdAsync(int id);
		Task<Order> CreateAsync(CreateOrderRequest request);
		Task<Order> UpdateAsync(int id, UpdateOrderRequest request);
		Task<bool> DeleteAsync(int id);
	}
}
