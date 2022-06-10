using System.ComponentModel.DataAnnotations;

namespace OrderCards.Domain.PersonModels
{
	public class CreatePersonRequest
	{
		[Key]
		public int PersonId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
