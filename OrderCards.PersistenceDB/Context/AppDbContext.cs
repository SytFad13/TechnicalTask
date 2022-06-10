using Microsoft.EntityFrameworkCore;
using OrderCards.Domain.OrderModels;
using OrderCards.Domain.PersonModels;

namespace OrderCards.PersistenceDB.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Person> Persons { get; set; }

		public DbSet<Order> Orders { get; set; }
	}
}
