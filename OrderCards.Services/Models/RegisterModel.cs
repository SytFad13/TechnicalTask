﻿using System.ComponentModel.DataAnnotations;

namespace OrderCards.Services.Models
{
	public class RegisterModel
	{
		[Key]
		public int Id { get; set; }
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
