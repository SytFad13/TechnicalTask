namespace OrderCards.Services.Abstractions
{
	public interface IHashingService
	{
		string HashPassword(string password);
		bool VerifyHashedPassword(string password, string storedHash);
	}
}
