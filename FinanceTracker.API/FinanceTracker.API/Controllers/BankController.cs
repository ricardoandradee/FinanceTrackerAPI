using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Application.Commands.Banks;
using FinanceTracker.Application.Dtos;
using FinanceTracker.Application.Queries.Banks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [UserAuthorization]
    [Route("api/user/{userId}/bank")]
    public class BankController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetBankById")]
        public async Task<IActionResult> GetBankById(int bankId)
        {
            var query = new GetBankByIdQuery(bankId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("GetBanksByUserId")]
        public async Task<IActionResult> GetBanksByUserId(int userId) 
        {
            var query = new GetBanksByUserIdQuery(userId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult) Ok(result) : NotFound(); 
        }

        [HttpPost]
        [Route("CreateBankWithAccount")]
        public async Task<IActionResult> CreateBankWithAccount(BankForCreationDto bankForCreationDto)
        {
            bankForCreationDto.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var command = new CreateBankWithAccountCommand(bankForCreationDto);

            var result = await _mediator.Send(command);
            
            return CreatedAtAction(nameof(GetBankById),
                new { bankId = result.Id, userId = bankForCreationDto.UserId }, result);
        }

        [HttpDelete]
        [Route("DeleteBankInfo/{bankId}")]
        [TypeFilter(typeof(BankAuthorizationAttribute))]
        public async Task<IActionResult> DeleteBankInfo(int bankId)
        {
            var command = new DeleteBankInfoCommand(bankId);
            var result = await _mediator.Send(command);

            if (result)
            {
                return NoContent();
            }

            throw new Exception("Error deleting the bank.");
        }

        [HttpPut]
        [Route("UpdateBankInfo/{bankId}")]
        [TypeFilter(typeof(BankAuthorizationAttribute))]
        public async Task<IActionResult> UpdateBankInfo(int bankId, BankForUpdateDto bankForUpdateDto)
        {
            var command = new UpdateBankInfoCommand(bankId, bankForUpdateDto);
            var result = await _mediator.Send(command);

            if (result)
            {
                return NoContent();
            }

            throw new Exception("Error updating the bank.");
        }
    }
}