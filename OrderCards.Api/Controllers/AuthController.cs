using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OrderCards.Domain.PersonModels;
using OrderCards.Services.Abstractions;
using OrderCards.Services.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace OrderCards.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
        private readonly IConfiguration _config;
        private readonly IPersonService _personService;

        public AuthController(IConfiguration config, IPersonService personService)
        {
            _config = config;
            _personService = personService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<Person>> Register(RegisterModel model)
        {
            await _personService.CreateAsync(model);

            return Ok(model);
        }

		[HttpPost]
		public async Task<ActionResult<string>> Login(LoginModel model)
		{
			var user = await Authenticate(model);

			if (user != null)
			{
				var token = Generate();
				return Ok(token);
			}

			return NotFound("User not found");
		}

		private string Generate()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<Person> Authenticate(LoginModel model)
        {
            var currentUser = await _personService.GetByModelAsync(model);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        
    }
}
