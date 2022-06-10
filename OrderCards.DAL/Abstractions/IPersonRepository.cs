using OrderCards.Domain.PersonModels;

namespace OrderCards.DAL.Abstractions
{
	public interface IPersonRepository
	{
		Task<ICollection<Person>> GetAllAsync();
		Task<Person> GetByIdAsync(int id);
		Task<Person> GetByModelAsync(Person person);
		Task<Person> CreateAsync(Person person);
	}
}
