using AutoMapper;
using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Models;
using FinanceTracker.Business.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [UserAuthorization]
    [Route("api/user/{userId}/account/{accountId}/transaction")]
        [TypeFilter(typeof(AccountAuthorizationAttribute))]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public TransactionController(ITransactionRepository transactionRepository,
                                     IMapper mapper)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }
        
        [HttpGet]
        [Route("GetTransaction/{transactionId}")]
        public async Task<IActionResult> GetTransaction(int userId, int accountId, int transactionId)
        {
            var transactionFromRepo = await _transactionRepository.RetrieveById(transactionId);
            var transactionToReturnDto = _mapper.Map<TransactionToReturnDto>(transactionFromRepo);
            return Ok(transactionToReturnDto);
        }

        [HttpGet]
        [Route("GetTransactions")]
        public async Task<IActionResult> GetTransactions(int userId, int accountId)
        {
            var transactionsFromRepo = await _transactionRepository.GetAccountsTransactions(accountId);
            var transactionsToReturnDto = _mapper.Map<IEnumerable<TransactionToReturnDto>>(transactionsFromRepo);
            return Ok(transactionsToReturnDto);
        }

        [HttpPost]
        [Route("PerformAccountTransaction")]
        public async Task<IActionResult> PerformAccountTransaction(int userId, int accountId,
        TransactionForCreationDto transactionForCreationDto)
        {
            var transactionOptions = new string[] { "Deposit", "Withdraw" };
            if (transactionForCreationDto.Amount <= 0)
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