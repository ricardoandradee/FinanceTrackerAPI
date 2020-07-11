using AutoMapper;
using FinanceTracker.API.Dtos;
using FinanceTracker.API.Models;
using FinanceTracker.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user/{userId}/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public PaymentController(IPaymentRepository paymentRepository,
            ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("GetPayment/{paymentId}")]
        public async Task<IActionResult> GetPayment(int userId, int paymentId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var paymentFromRepo = await _paymentRepository.RetrieveById(paymentId);

            if (paymentFromRepo == null)
            {
                return BadRequest($"PaymentId {paymentId} was not found.");
            }
            else if (await _paymentRepository.PaymentBelongsToUser(userId, paymentId))
            {
                return BadRequest($"User does not have access to payment id {paymentId}");
            }

            var paymentToReturnDto = _mapper.Map<PaymentToReturnDto>(paymentFromRepo);
            return Ok(paymentToReturnDto);
        }

        [HttpGet]
        [Route("GetPaymentsForUser")]
        public async Task<IActionResult> GetPaymentsForUser(int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var paymentsFromRepo = await _paymentRepository.GetPaymentsForUser(userId);
            var paymentsToReturnDto = _mapper.Map<IList<PaymentToReturnDto>>(paymentsFromRepo);

            return Ok(paymentsToReturnDto);
        }

        [HttpPost]
        [Route("CreatePayment")]
        public async Task<IActionResult> CreatePayment(int userId, PaymentForCreationDto paymentForCreationDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            
            var categoryId = paymentForCreationDto.CategoryId;

            if (await _categoryRepository.RetrieveById(categoryId) == null)
            {
                return BadRequest($"CategoryId {categoryId} was not found.");
            }
            else if (await _categoryRepository.CategoryBelongsToUser(userId, categoryId) == false)
            {
                return BadRequest($"Category id {categoryId} does not belong to the logged in user.");
            }

            var payment = _mapper.Map<Payment>(paymentForCreationDto);

            if (await _paymentRepository.Add(payment))
            {
                var paymentToReturn = _mapper.Map<PaymentToReturnDto>(payment);
                return CreatedAtAction(nameof(GetPayment),
                    new { paymentId = payment.Id, userId = userId }, paymentToReturn);
            }

            throw new Exception("Creating payment failed on save.");
        }

        [HttpDelete]
        [Route("DeletePayment/{paymentId}")]
        public async Task<IActionResult> DeletePayment(int paymentId)
        {
            var paymentFromRepo = await _paymentRepository.RetrieveById(paymentId);

            if (await _paymentRepository.Delete(paymentFromRepo))
                return NoContent();

            throw new Exception("Error deleting the payment.");
        }

        [HttpPut]
        [Route("UpdatePayment/{paymentId}")]
        public async Task<IActionResult> UpdatePayment(int paymentId, PaymentForUpdateDto paymentForUpdateDto)
        {
            var paymentFromRepo = await _paymentRepository.RetrieveById(paymentId);
            _mapper.Map(paymentForUpdateDto, paymentFromRepo);

            if (await _paymentRepository.Update(paymentFromRepo))
            {
                return NoContent();
            }

            throw new Exception($"Update Payment {paymentId} failed on save.");
        }
    }
}