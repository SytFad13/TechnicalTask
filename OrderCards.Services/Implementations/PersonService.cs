using OrderCards.DAL.Abstractions;
using OrderCards.Domain.PersonModels;
using OrderCards.Services.Abstractions;
using OrderCards.Services.Models;

namespace OrderCards.Services.Implementations
{
	public class PersonService : IPersonService
	{
		private readonly IPersonRepository _personRepo;

		public PersonService(IPersonRepository personRepo)
		{
			_personRepo = personRepo;
		}

		public async Task<ICollection<PersonResponseModel>> GetAllAsync()
		{
			var persons = await _personRepo.GetAllAsync();

			var personResponseModels = persons.Select(x => new PersonResponseModel()
			{
				PersonId = x.PersonId,
				FirstName = x.FirstName,
				LastName = x.LastName,
				Email = x.Email,
				Password = x.Password
			}).ToList();

			return personResponseModels;
		}

		public async Task<PersonResponseModel> GetByIdAsync(int id)
		{
			var person = await _personRepo.GetByIdAsync(id);

			var personResponseModel = new PersonResponseModel()
			{
				PersonId = person.PersonId,
				FirstName = person.FirstName,
				LastName = person.LastName,
				Email = person.Email,
				Password = person.Password
			};

			return personResponseModel;
		}

		public async Task<Person> GetByModelAsync(LoginModel model)
		{
			Person person = new()
			{
				Email = model.Email,
				Password = model.Password,
			};

			var currentPerson = await _personRepo.GetByModelAsync(person);

			return currentPerson;
		}

		public async Task<Person> CreateAsync(RegisterModel model)
		{
			Person person = new()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				Password = model.Password,
			};

			await _personRepo.CreateAsync(person);

			return person;
		}
	}
}
