using CleanArch.Application.Users.Register;
using CleanArch.Query.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public AuthController(IMediator mediator, IConfiguration configuration)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand command)
        {
            var Result = await _mediator.Send(command);
            return Created("", Result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            var User = await _mediator.Send(new GetUserByEmailQuery(Email));
            if (User == null)
                return NotFound("User Not Founded");
            if (User.Phone != Password)
                return NotFound("User Not Founded");

            var Claims = new List<Claim>()
            {
                new Claim("email",User.Email),
                new Claim(ClaimTypes.NameIdentifier,User.Id.ToString())
            };
            var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:SignInKey"]));
            var Credentials = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken(
                issuer: _configuration["JwtConfig:Issuer"],
                audience: _configuration["JwtConfig:Audience"],
                claims: Claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: Credentials
                );
            var JwtToken = new JwtSecurityTokenHandler().WriteToken(Token);
            return Ok(JwtToken);
        }
    }
}
