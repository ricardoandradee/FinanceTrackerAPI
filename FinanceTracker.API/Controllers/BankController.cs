using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Application.Commands.Accounts;
using FinanceTracker.Application.Commands.Banks;
using FinanceTracker.Application.Dtos.Accounts;
using FinanceTracker.Application.Dtos.Banks;
using FinanceTracker.Application.Queries.Accounts;
using FinanceTracker.Application.Queries.Banks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [UserAuthorization]
    [Route("api/user/{userId}/bank")]
    public class BankController : ApiController
    {

        [HttpGet]
        [Route("{bankId}/account/GetAccountByBankId")]
        public async Task<IActionResult> GetAccountByBankId(int bankId)
        {
            var query = new GetAccountByBankIdQuery(bankId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        [Route("{bankId}/account/CreateAccount")]
        public async Task<IActionResult> CreateAccount(int userId, int bankId, AccountForCreationDto accountForCreationDto)
        {
            var command = new CreateAccountCommand(accountForCreationDto);
            var result = await Mediator.Send(command);

            return CreatedAtAction(nameof(AccountController.GetAccountById),
                "Account",
                new { accountId = result.Id, bankId, userId },
                result);
        }

        [HttpGet]
        [Route("{bankId}/GetBankById")]
        public async Task<IActionResult> GetBankById(int bankId)
        {
            var query = new GetBankByIdQuery(bankId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("GetBanksByUserId")]
        public async Task<IActionResult> GetBanksByUserId(int userId) 
        {
            var query = new GetBanksByUserIdQuery(userId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult) Ok(result) : NotFound(); 
        }

        [HttpPost]
        [Route("CreateBankWithAccount")]
        public async Task<IActionResult> CreateBankWithAccount(int userId, BankForCreationDto bankForCreationDto)
        {
            bankForCreationDto.UserId = userId;
            var command = new CreateBankWithAccountCommand(bankForCreationDto);

            var result = await Mediator.Send(command);
            
            return CreatedAtAction(nameof(GetBankById),
                new { bankId = result.Id, userId = bankForCreationDto.UserId }, result);
        }

        [HttpDelete]
        [Route("{bankId}/DeleteBankInfo")]
        public async Task<IActionResult> DeleteBankInfo(int bankId)
        {
            var command = new DeleteBankInfoCommand(bankId);
            var result = await Mediator.Send(command);

            if (result)
            {
                return NoContent();
            }

            throw new Exception("Error deleting the bank.");
        }

        [HttpPut]
        [Route("{bankId}/UpdateBankInfo")]
        public async Task<IActionResult> UpdateBankInfo(int bankId, BankForUpdateDto bankForUpdateDto)
        {
            var command = new UpdateBankInfoCommand(bankId, bankForUpdateDto);
            var result = await Mediator.Send(command);

            if (result)
            {
                return NoContent();
            }

            throw new Exception("Error updating the bank.");
        }
    }
}