using Microsoft.EntityFrameworkCore;
using OrderCards.DAL.Abstractions;
using OrderCards.Domain.OrderModels;
using OrderCards.PersistenceDB.Context;

namespace OrderCards.DAL.Implementations
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _dbContext;

		public OrderRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<ICollection<Order>> GetAllAsync()
		{
			return await _dbContext.Orders.AsNoTracking().ToListAsync();
		}

		public async Task<Order> GetByIdAsync(int id)
		{
			return await _dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(c => c.OrderId == id);
		}

		public async Task<Order> CreateAsync(Order order)
		{
			await _dbContext.Orders.AddAsync(order);
			await _dbContext.SaveChangesAsync();
			return order;
		}

		public async Task<Order> UpdateAsync(Order order)
		{
			_dbContext.Orders.Update(order);
			await _dbContext.SaveChangesAsync();

			return order;
		}

		public async Task DeleteAsync(Order order)
		{
			_dbContext.Orders.Remove(order);
			await _dbContext.SaveChangesAsync();
		}
	}
}
