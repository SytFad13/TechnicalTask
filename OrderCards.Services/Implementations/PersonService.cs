using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using OrderCards.DAL.Abstractions;
using OrderCards.Domain.PersonModels;
using OrderCards.Services.Abstractions;
using OrderCards.Services.Models;
using System.Security.Cryptography;

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

		public async Task<Person> GetByIdAsync(int id)
		{
			var person = await _personRepo.GetByIdAsync(id);

			return person;
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
			byte[] salt = new byte[128 / 8];
			using (var rngCsp = RandomNumberGenerator.Create())
			{
				rngCsp.GetNonZeroBytes(salt);
			}

			string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
			    password: model.Password,
			    salt: salt,
			    prf: KeyDerivationPrf.HMACSHA256,
			    iterationCount: 100000,
			    numBytesRequested: 256 / 8));


			Person person = new()
			{
				PersonId = model.Id,
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				Password = hashed,
			};

			await _personRepo.CreateAsync(person);

			return person;
		}
	}
}
