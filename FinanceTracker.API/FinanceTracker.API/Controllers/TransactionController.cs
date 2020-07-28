using System.Linq;
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
    [Route("api/user/{userId}/account/{accountId}/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public TransactionController(ITransactionRepository transactionRepository, IAccountRepository accountRepository,
                                 IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _unitOfWorkRepository = unitOfWorkRepository;
        }
        
        [HttpGet]
        [Route("GetTransaction/{transactionId}")]
        public async Task<IActionResult> GetTransaction(int userId, int accountId, int transactionId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            if (await _accountRepository.BelongsToUser(userId, accountId) == false)
            {
                return BadRequest("This account does not belong to the logged in user.");
            }

            var transactionFromRepo = _transactionRepository.RetrieveById(transactionId);
            var transactionToReturnDto = _mapper.Map<TransactionToReturnDto>(transactionFromRepo);
            return Ok(transactionToReturnDto);
        }

        [HttpGet]
        [Route("GetTransactions")]
        public async Task<IActionResult> GetTransactions(int userId, int accountId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            if (await _accountRepository.BelongsToUser(userId, accountId) == false)
            {
                return BadRequest("This account does not belong to the logged in user.");
            }

            var transactionsFromRepo = _transactionRepository.GetAccountsTransactions(accountId);
            var transactionsToReturnDto = _mapper.Map<IEnumerable<TransactionToReturnDto>>(transactionsFromRepo);
            return Ok(transactionsToReturnDto);
        }

        [HttpPost]
        [Route("PerformAccountTransaction")]
        public async Task<IActionResult> PerformAccountTransaction(int userId, int accountId,
        TransactionForCreationDto transactionForCreationDto)
        {
            var transactionOptions = new string[] { "Deposit", "Withdraw" };
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            } else if (await _accountRepository.BelongsToUser(userId, accountId) == false)
            {
                return BadRequest("This account does not belong to the logged in user.");
            } else if (transactionForCreationDto.Amount <= 0)
            {
                throw new InvalidOperationException("Transaction amount cannot be less or equals to zero.");
            } else if (!transactionOptions.Contains(transactionForCreationDto.Action))
            {
                throw new InvalidOperationException($"{transactionForCreationDto.Action} is not recognized as a transaction.");
            }

            var transactionToCreate = _mapper.Map<Transaction>(transactionForCreationDto);
            var transactionCreated = await _transactionRepository.PerformAccountTransaction(transactionToCreate);

            if (transactionCreated != null)
            {
                var transactionToReturn = _mapper.Map<TransactionToReturnDto>(transactionCreated);

                return CreatedAtAction(nameof(GetTransaction), 
                    new { transactionId = transactionToReturn.Id, accountId, userId },
                    transactionToReturn);
            }

            throw new Exception("Creating transaction failed on save.");
        }
    }
}