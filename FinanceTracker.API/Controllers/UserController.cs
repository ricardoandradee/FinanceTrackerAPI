using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Application.Commands.Users;
using FinanceTracker.Application.Dtos.Users;
using FinanceTracker.Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [Route("api/user/{userId}")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var query = new GetUserByIdQuery(userId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPut]
        [UserAuthorization]
        [Route("UpdateUserBaseCurrency/{currencyId}")]
        public async Task<IActionResult> UpdateUserBaseCurrency(int userId, int currencyId)
        {
            var command = new UpdateUserBaseCurrencyCommand(userId, currencyId);
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

        [HttpPut]
        [UserAuthorization]
        [Route("UpdateUserSettings")]
        public async Task<IActionResult> UpdateUserSettings(int userId, UserForUpdateDto userForUpdateDto)
        {
            var command = new UpdateUserSettingsCommand(userId, userForUpdateDto);
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