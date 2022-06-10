using OrderCards.Domain.PersonModels;
using OrderCards.Services.Models;

namespace OrderCards.Services.Abstractions
{
	public interface IPersonService
	{
		Task<ICollection<PersonResponseModel>> GetAllAsync();
		Task<Person> GetByIdAsync(int id);
		Task<Person> GetByModelAsync(LoginModel model);
		Task<Person> CreateAsync(RegisterModel model);
	}
}
