using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.API.Dtos;
using FinanceTracker.API.Models;
using FinanceTracker.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [UserAuthorization]
    [Route("api/user/{userId}/bank")]
    public class BankController : ControllerBase
    {
        private readonly IBankRepository _bankRepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public BankController(IBankRepository bankRepository,
                                 IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetBankInfo")]
        public async Task<IActionResult> GetBankInfo(int userId, int bankId) 
        {
            var bankFromRepo = await _bankRepository.RetrieveById(userId);
            var bankToReturnDto = _mapper.Map<BankToReturnDto>(bankFromRepo);

            return Ok(bankToReturnDto);
        }

        [HttpGet]
        [Route("GetBanksForUser")]
        public async Task<IActionResult> GetBanksForUser(int userId) 
        {
            var banksFromRepo = await _bankRepository.GetBanksForUser(userId);
            var banksToReturnDto = _mapper.Map<IList<BankToReturnDto>>(banksFromRepo);

            return Ok(banksToReturnDto);            
        }

        [HttpPost]
        [Route("CreateBankWithAccount")]
        public async Task<IActionResult> CreateBankWithAccount(BankForCreationDto bankForCreationDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            bankForCreationDto.UserId = userId;

            var bankToBeCreated = _mapper.Map<Bank>(bankForCreationDto);
            var createdBank = await _bankRepository.CreateBankWithAccount(bankToBeCreated);

            if (createdBank != null)
            {
                var bankToReturn = _mapper.Map<BankToReturnDto>(createdBank);
                return CreatedAtAction(nameof(GetBankInfo),
                    new { bankId = bankToReturn.Id, userId }, bankToReturn);
            }

            throw new Exception("Creating bank failed on save.");
        }

        [HttpDelete]
        [Route("DeleteBankInfo/{bankId}")]
        [TypeFilter(typeof(BankAuthorizationAttribute))]
        public async Task<IActionResult> DeleteBankInfo(int userId, int bankId)
        {
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
        [TypeFilter(typeof(BankAuthorizationAttribute))]

        public async Task<IActionResult> UpdateBankInfo(int userId, int bankId, BankForUpdateDto bankForUpdateDto)
        {
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