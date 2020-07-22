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
    [Route("api/user/{userId}/bank")]
    public class BankController : ControllerBase
    {
        private readonly IBankRepository _bankRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public BankController(IBankRepository bankRepository, IAccountRepository accountRepository,
                                 IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _bankRepository = bankRepository;
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetBankInfo")]
        public async Task<IActionResult> GetBankInfo(int userId, int bankId) 
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var bankFromRepo = await _bankRepository.RetrieveById(userId);
            var bankToReturnDto = _mapper.Map<BankToReturnDto>(bankFromRepo);

            return Ok(bankToReturnDto);
        }

        [HttpGet]
        [Route("GetBanksForUser")]
        public async Task<IActionResult> GetBanksForUser(int userId) 
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var banksFromRepo = await _bankRepository.GetBanksForUser(userId);
            var banksToReturnDto = _mapper.Map<IList<BankToReturnDto>>(banksFromRepo);

            return Ok(banksToReturnDto);            
        }

        [HttpPost]
        [Route("CreateBankInfo")]
        public async Task<IActionResult> CreateBankInfo(BankForCreationDto bankForCreationDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            bankForCreationDto.UserId = userId;

            var bank = _mapper.Map<Bank>(bankForCreationDto);
            await _bankRepository.Add(bank);

            if (await _unitOfWorkRepository.SaveChanges() > 0)
            {
                var bankToReturn = _mapper.Map<BankToReturnDto>(bank);
                return CreatedAtAction(nameof(GetBankInfo),
                    new { bankId = bank.Id, userId },
                    bankToReturn);
            }

            throw new Exception("Creating bank failed on save.");
        }

        [HttpDelete]
        [Route("DeleteBankInfo/{bankId}")]
        public async Task<IActionResult> DeleteBankInfo(int userId, int bankId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            // if (await _bankRepository.ExistsAnyTransactionsConnectedToBank(id))
            // {
            //     return BadRequest("This category has payments linked to it, therefore, it cannot be removed.");
            // }

            if (await _bankRepository.BelongsToUser(userId, bankId) == false)
            {
                return BadRequest("This bank does not belong to the logged in user.");
            }

            var bankFromRepo = await _bankRepository.RetrieveById(bankId);
            _bankRepository.Delete(bankFromRepo);

            if (await _unitOfWorkRepository.SaveChanges() > 0)
            {
                return NoContent();
            }

            throw new Exception("Error deleting the bank.");
        }

        [HttpPut]
        [Route("UpdateBankInfo/{bankId}")]
        public async Task<IActionResult> UpdateBankInfo(int userId, int bankId, BankForUpdateDto bankForUpdateDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            if (await _bankRepository.BelongsToUser(userId, bankId) == false)
            {
                return BadRequest("This bank does not belong to the logged in user.");
            }

            var bankFromRepo = await _bankRepository.RetrieveById(bankId);
            _mapper.Map(bankForUpdateDto, bankFromRepo);
            
            if (await _unitOfWorkRepository.SaveChanges() > 0)
            {
                return NoContent();
            }

            throw new Exception("Error updating the bank.");
        }
    }
}