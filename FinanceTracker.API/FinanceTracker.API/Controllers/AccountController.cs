using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FinanceTracker.API.Dtos;
using FinanceTracker.API.Models;
using FinanceTracker.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user/{userId}/bank/{bankId}/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;
        public AccountController(IAccountRepository accountRepository, IBankRepository bankRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
            _accountRepository = accountRepository;
        }
        
        [HttpGet]
        [Route("GetAccount/{accountId}")]
        public async Task<IActionResult> GetAccount(int userId, int bankId, int accountId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            if (await _bankRepository.BelongsToUser(userId, bankId) == false)
            {
                return BadRequest("This bank does not belong to the logged in user.");
            }

            var accountFromRepo = _accountRepository.RetrieveById(accountId);
            var accountToReturnDto = _mapper.Map<AccountToReturnDto>(accountFromRepo);
            return Ok(accountToReturnDto);
        }

        [HttpGet]
        [Route("GetAccount/{accountId}")]
        public async Task<IActionResult> GetAccountsForBank(int userId, int bankId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            if (await _bankRepository.BelongsToUser(userId, bankId) == false)
            {
                return BadRequest("This bank does not belong to the logged in user.");
            }

            var accountsFromRepo = _bankRepository.GetAllAccounts(bankId);
            var accountsToReturnDto = _mapper.Map<IEnumerable<AccountToReturnDto>>(accountsFromRepo);
            return Ok(accountsToReturnDto);
        }

        [HttpPost]
        [Route("CreateAccount")]
        public async Task<IActionResult> CreateAccout(int userId, int bankId, AccountForCreationDto accountForCreationDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            if (await _bankRepository.BelongsToUser(userId, bankId) == false)
            {
                return BadRequest("This bank does not belong to the logged in user.");
            }

            var account = _mapper.Map<Account>(accountForCreationDto);

            if(await _accountRepository.Add(account))
            {
                var accountToReturn = _mapper.Map<AccountToReturnDto>(account);

                return CreatedAtAction(nameof(GetAccount), 
                    new { accountId = account.Id, bankId = bankId, userId = userId },
                    accountToReturn);
            }

            throw new Exception("Creating account failed on save.");
        }

        [HttpPut]
        [Route("UpdateAccount/{accountId}")]
        public async Task<IActionResult> UpdateAccount(int userId, int bankId, int accountId, AccountForUpdateDto accountForUpdateDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            if (await _bankRepository.BelongsToUser(userId, bankId) == false)
            {
                return BadRequest("This account does not belong to the logged in user.");
            }

            var accountFromRepo = await _accountRepository.RetrieveById(bankId);
            _mapper.Map(accountForUpdateDto, accountFromRepo);

            if (await _accountRepository.Update(accountFromRepo))
            {
                return NoContent();
            }

            throw new Exception("Error updating the account.");
        }

        [HttpDelete]
        [Route("DeleteAccount/{accountId}")]
        public async Task<IActionResult> DeleteAccount(int userId, int accountId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            if (await _accountRepository.BelongsToUser(userId, accountId) == false)
            {
                return BadRequest("This bank does not belong to the logged in user.");
            }

            var accountFromRepo = await _accountRepository.RetrieveById(accountId);

            if (await _accountRepository.Delete(accountFromRepo))
            {
                return NoContent();
            }

            throw new Exception("Error deleting the account.");
        }
    }
}