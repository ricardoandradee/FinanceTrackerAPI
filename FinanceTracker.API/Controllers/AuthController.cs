using FinanceTracker.API.EmailHandling;
using FinanceTracker.Application.Commands.Users;
using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Users;
using FinanceTracker.Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [Route("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IConfiguration _config;
        private readonly IEmailSender _emailSender;

        public AuthController(IConfiguration config,
            IEmailSender emailSender)
        {
            _config = config;
            _emailSender = emailSender;
        }


        [HttpGet]
        [Route("GetExistingUsersDetails")]
        public async Task<IActionResult> GetExistingUsersDetails()
        {
            var query = new GetExistingUsersDetailsQuery();
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : BadRequest();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var command = new RegisterUserCommand(userForRegisterDto);
            var result = await Mediator.Send(command);

            if (result == null) return BadRequest();
            if (!result.Ok) return Ok(result);

            return await SendAccountVerificationEmail(result);
        }

        private async Task<IActionResult> SendAccountVerificationEmail(Response<UserForDetailDto> result)
        {
            var emailResult = await _emailSender.SendVerificationEmail(new UserEmailDto
            {
                EmailTo = result.Data.Email,
                NameTo = result.Data.FullName
            });

            return emailResult == null ? (IActionResult)NotFound() : Ok(emailResult);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var command = new LoginUserCommand(userForLoginDto);
            var result = await Mediator.Send(command);

            if (result != null)
            {
                return Ok(new LoginResponseDto
                {
                    Token = result.Ok ? GenerateToken(userForLoginDto.Email, result.Data.Id) : "",
                    User = result
                });
            }

            return BadRequest();
        }

        private string GenerateToken(string email, int userId)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("Jwt:Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds,
                Issuer = _config.GetSection("Jwt:Issuer").Value
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}