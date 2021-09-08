using FinanceTracker.Application.Commands.Email;
using FinanceTracker.Application.Commands.Users;
using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Email;
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

        public AuthController(IConfiguration config)
        {
            _config = config;
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

        [NonAction]
        private async Task<IActionResult> SendAccountVerificationEmail(Response<UserForDetailDto> response)
        {
            var command = new SendAccountVerificationEmailCommand(new UserEmailDto()
            {
                EmailTo = response.Data.Email,
                NameTo = response.Data.FullName,
                UserId = response.Data.Id,
                ConfirmationCode = response.Data.ConfirmationCode ?? Guid.Empty
            });

            var result = await Mediator.Send(command);

            return result == null ? (IActionResult)NotFound() : Ok(result);
        }

        [HttpPost]
        [Route("ConfirmUserRegistration")]
        public async Task<IActionResult> ConfirmUserRegistration(UserValidationDto userValidationDto)
        {
            var command = new ConfirmUserRegistrationCommand(userValidationDto);
            var result = await Mediator.Send(command);

            return result == null ? (IActionResult)BadRequest() : Ok(result);
        }

        [HttpGet]
        [Route("SendPasswordResetEmail")]
        public async Task<IActionResult> SendPasswordResetEmail([FromQuery] string email)
        {
            var command = new SendPasswordResetEmailCommand(email);
            var result = await Mediator.Send(command);
            return result == null ? (IActionResult)BadRequest() : Ok(result);
        }

        [HttpPost]
        [Route("ResetUserPassword")]
        public async Task<IActionResult> ResetUserPassword(UserPasswordResetDto userPasswordResetDto)
        {
            var command = new ResetUserPasswordCommand(userPasswordResetDto);
            var result = await Mediator.Send(command);

            return result == null ? (IActionResult)BadRequest() : Ok(result);
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