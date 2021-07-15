using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Application.Commands.Accounts;
using FinanceTracker.Application.Dtos.Accounts;
using FinanceTracker.Application.Queries.Accounts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [UserAuthorization]
    [Route("api/user/{userId}/account/{accountId}")]
    public class AccountController : ApiController
    {        
        [HttpGet]
        [Route("GetAccountById")]
        public async Task<IActionResult> GetAccountById(int accountId)
        {
            var query = new GetAccountByIdQuery(accountId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPut]
        [Route("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount(int accountId, AccountForUpdateDto accountForUpdateDto)
        {
            var command = new UpdateAccountCommand(accountForUpdateDto, accountId);
            var result = await Mediator.Send(command);

            if (result)
            {
                return NoContent();
            }

            throw new Exception("Error updating the account.");
        }

        [HttpDelete]
        [Route("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount(int accountId)
        {
            var command = new DeleteAccountCommand(accountId);
            var result = await Mediator.Send(command);

            if (result)
            {
                return NoContent();
            }

            throw new Exception("Error deleting the account.");
        }
    }
}