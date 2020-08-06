using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Application.Commands.Accounts;
using FinanceTracker.Application.Dtos;
using FinanceTracker.Application.Queries.Accounts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [UserAuthorization]
    [TypeFilter(typeof(BankAuthorizationAttribute))]
    [Route("api/user/{userId}/bank/{bankId}/account")]
    public class AccountController : ApiController
    {        
        [HttpGet]
        [Route("GetAccountById/{accountId}")]
        [TypeFilter(typeof(AccountAuthorizationAttribute))]
        public async Task<IActionResult> GetAccountById(int accountId)
        {
            var query = new GetAccountByIdQuery(accountId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("GetAccountByBankId")]
        public async Task<IActionResult> GetAccountByBankId(int bankId)
        {
            var query = new GetAccountByBankIdQuery(bankId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPut]
        [Route("UpdateAccount/{accountId}")]
        [TypeFilter(typeof(AccountAuthorizationAttribute))]
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
        [Route("DeleteAccount/{accountId}")]
        [TypeFilter(typeof(AccountAuthorizationAttribute))]
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

        [HttpPost]
        [Route("CreateAccount")]
        public async Task<IActionResult> CreateAccount(int userId, int bankId, AccountForCreationDto accountForCreationDto)
        {
            var command = new CreateAccountCommand(accountForCreationDto);
            var result = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetAccountById),
                new { accountId = result.Id, bankId, userId },
                result);
        }
    }
}