namespace OrderCards.DAL.Abstractions
{
	public interface IRepository<T>
	{
		Task<ICollection<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task<T> CreateAsync(T model);
		Task<T> UpdateAsync(T model);
		Task DeleteAsync(T model);
	}
}
