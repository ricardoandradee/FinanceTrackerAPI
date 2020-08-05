using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Business.Commands;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Models;
using FinanceTracker.Business.Queries;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [UserAuthorization]
    [TypeFilter(typeof(BankAuthorizationAttribute))]
    [Route("api/user/{userId}/bank/{bankId}/account")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        [Route("GetAccountById/{accountId}")]
        [TypeFilter(typeof(AccountAuthorizationAttribute))]
        public async Task<IActionResult> GetAccountById(int accountId)
        {
            var query = new GetAccountByIdQuery(accountId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAccountByBankId")]
        public async Task<IActionResult> GetAccountByBankId(int bankId)
        {
            var query = new GetAccountByBankIdQuery(bankId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPut]
        [Route("UpdateAccount/{accountId}")]
        [TypeFilter(typeof(AccountAuthorizationAttribute))]
        public async Task<IActionResult> UpdateAccount(int accountId, AccountForUpdateDto accountForUpdateDto)
        {
            var command = new UpdateAccountCommand(accountForUpdateDto, accountId);
            var result = await _mediator.Send(command);

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
            var result = await _mediator.Send(command);

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
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetAccountById),
                new { accountId = result.Id, bankId, userId },
                result);
        }
    }
}