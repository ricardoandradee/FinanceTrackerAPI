using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Application.Commands.Accounts;
using FinanceTracker.Application.Dtos.Transactions;
using FinanceTracker.Application.Queries.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [UserAuthorization]
    [Route("api/user/{userId}/account/{accountId}/transaction")]
    [TypeFilter(typeof(AccountAuthorizationAttribute))]
    public class TransactionController : ApiController
    {
        [HttpGet]
        [Route("GetTransactionById/{transactionId}")]
        public async Task<IActionResult> GetTransactionById(int transactionId)
        {
            var query = new GetTransactionByIdQuery(transactionId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("GetTransactionsByAccountId")]
        public async Task<IActionResult> GetTransactionsByAccountId(int accountId)
        {
            var query = new GetTransactionsByAccountIdQuery(accountId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        [Route("PerformAccountTransaction")]
        public async Task<IActionResult> PerformAccountTransaction(int userId, int accountId,
        TransactionForCreationDto transactionForCreationDto)
        {
            var command = new PerformAccountTransactionCommand(transactionForCreationDto);
            var result = await Mediator.Send(command);

            if (result != null)
            {
                return CreatedAtAction(nameof(GetTransactionById),
                    new { transactionId = result.Id, accountId, userId },
                    result);
            }

            return NotFound();
        }
    }
}