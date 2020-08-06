using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Application.Commands.Users;
using FinanceTracker.Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("api/user/{userId}")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var query = new GetUserByIdQuery(userId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPut]
        [UserAuthorization]
        [Route("UpdateUserBaseCurrency/{userCurrency}")]
        public async Task<IActionResult> UpdateUserBaseCurrency(int userId, string userCurrency)
        {
            var command = new UpdateUserBaseCurrencyCommand(userId, userCurrency);
            var result = await _mediator.Send(command);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}