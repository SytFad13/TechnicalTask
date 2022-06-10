namespace OrderCards.Services.Models
{
	public class RegisterModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }


		public RegisterModel(string firstName, string lastName, string email, string password)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Password = password;
		}
	}
}
