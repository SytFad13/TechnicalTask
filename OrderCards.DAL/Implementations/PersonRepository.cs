using Microsoft.EntityFrameworkCore;
using OrderCards.DAL.Abstractions;
using OrderCards.Domain.PersonModels;
using OrderCards.PersistenceDB.Context;

namespace OrderCards.DAL.Implementations
{
	public class PersonRepository : IPersonRepository
	{
		private readonly AppDbContext _dbContext;

		public PersonRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<ICollection<Person>> GetAllAsync()
		{
			return await _dbContext.Persons.AsNoTracking().ToListAsync();
		}

		public async Task<Person> GetByIdAsync(int id)
		{
			return await _dbContext.Persons.AsNoTracking().FirstOrDefaultAsync(c => c.PersonId == id);
		}

		public async Task<Person> GetByModelAsync(Person person)
		{
			return await _dbContext.Persons.AsNoTracking().FirstOrDefaultAsync(c => c.Email.ToLower() == person.Email.ToLower());
		}

		public async Task<Person> CreateAsync(Person person)
		{
			await _dbContext.Persons.AddAsync(person);
			await _dbContext.SaveChangesAsync();
			return person;
		}
	}
}
