using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Models;
using FinanceTracker.Business.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [UserAuthorization]
    [TypeFilter(typeof(BankAuthorizationAttribute))]
    [Route("api/user/{userId}/bank/{bankId}/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IBankRepository _bankRepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public AccountController(IAccountRepository accountRepository, IBankRepository bankRepository,
                                 IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
            _unitOfWorkRepository = unitOfWorkRepository;
            _accountRepository = accountRepository;
        }
        
        [HttpGet]
        [Route("GetAccount/{accountId}")]
        [TypeFilter(typeof(AccountAuthorizationAttribute))]
        public async Task<IActionResult> GetAccount(int userId, int accountId)
        {
            var accountFromRepo = await _accountRepository.RetrieveById(accountId);
            var accountToReturnDto = _mapper.Map<AccountToReturnDto>(accountFromRepo);
            return Ok(accountToReturnDto);
        }

        [HttpPut]
        [Route("UpdateAccount/{accountId}")]
        [TypeFilter(typeof(AccountAuthorizationAttribute))]
        public async Task<IActionResult> UpdateAccount(int userId, int accountId, AccountForUpdateDto accountForUpdateDto)
        {
            var accountFromRepo = await _accountRepository.RetrieveById(accountId);
            _mapper.Map(accountForUpdateDto, accountFromRepo);

            if (await _unitOfWorkRepository.SaveChanges() > 0)
            {
                return NoContent();
            }

            throw new Exception("Error updating the account.");
        }

        [HttpDelete]
        [Route("DeleteAccount/{accountId}")]
        [TypeFilter(typeof(AccountAuthorizationAttribute))]
        public async Task<IActionResult> DeleteAccount(int userId, int accountId)
        {
            var accountFromRepo = await _accountRepository.RetrieveById(accountId);
            _accountRepository.Delete(accountFromRepo);

            if (await _unitOfWorkRepository.SaveChanges() > 0)
            {
                return NoContent();
            }

            throw new Exception("Error deleting the account.");
        }

        [HttpGet]
        [Route("GetAccountsForBank")]
        public async Task<IActionResult> GetAccountsForBank(int userId, int bankId)
        {
            var accountsFromRepo = await _bankRepository.GetAllAccounts(bankId);
            var accountsToReturnDto = _mapper.Map<IEnumerable<AccountToReturnDto>>(accountsFromRepo);
            return Ok(accountsToReturnDto);
        }

        [HttpPost]
        [Route("CreateAccount")]
        public async Task<IActionResult> CreateAccount(int userId, int bankId, AccountForCreationDto accountForCreationDto)
        {
            var accountToBeCreated = _mapper.Map<Account>(accountForCreationDto);
            var createdAccount = await _accountRepository.CreateAccount(accountToBeCreated);

            if (createdAccount != null)
            {
                var accountToReturn = _mapper.Map<AccountToReturnDto>(createdAccount);
                return CreatedAtAction(nameof(GetAccount), 
                    new { accountId = accountToReturn.Id, bankId, userId },
                    accountToReturn);
            }

            throw new Exception("Creating account failed on save.");
        }
    }
}