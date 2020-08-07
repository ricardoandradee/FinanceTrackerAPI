using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Application.Commands.Users;
using FinanceTracker.Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [Route("api/user/{userId}")]
    public class UserController : ApiController
    {
        [HttpGet(Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var query = new GetUserByIdQuery(userId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPut]
        [UserAuthorization]
        [Route("UpdateUserBaseCurrency/{baseCurrency}")]
        public async Task<IActionResult> UpdateUserBaseCurrency(int userId, string baseCurrency)
        {
            var command = new UpdateUserBaseCurrencyCommand(userId, baseCurrency);
            var result = await Mediator.Send(command);

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