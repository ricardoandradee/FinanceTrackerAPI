using AutoMapper;
using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.API.Dtos;
using FinanceTracker.API.Models;
using FinanceTracker.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [UserAuthorization]
    [Route("api/user/{userId}/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentRepository paymentRepository, ICategoryRepository categoryRepository,
                                 IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _categoryRepository = categoryRepository;
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetPayment/{paymentId}")]
        [TypeFilter(typeof(PaymentAuthorizationAttribute))]
        public async Task<IActionResult> GetPayment(int userId, int paymentId)
        {
            var paymentFromRepo = await _paymentRepository.RetrieveById(paymentId);
            var paymentToReturnDto = _mapper.Map<PaymentToReturnDto>(paymentFromRepo);
            return Ok(paymentToReturnDto);
        }

        [HttpDelete]
        [Route("DeletePayment/{paymentId}")]
        [TypeFilter(typeof(PaymentAuthorizationAttribute))]
        public async Task<IActionResult> DeletePayment(int paymentId)
        {
            var paymentFromRepo = await _paymentRepository.RetrieveById(paymentId);
            _paymentRepository.Delete(paymentFromRepo);

            if (await _unitOfWorkRepository.SaveChanges() > 0)
            {
                return NoContent();
            }

            throw new Exception("Error deleting the payment.");
        }

        [HttpPut]
        [Route("UpdatePayment/{paymentId}")]
        [TypeFilter(typeof(PaymentAuthorizationAttribute))]
        public async Task<IActionResult> UpdatePayment(int paymentId, PaymentForUpdateDto paymentForUpdateDto)
        {
            var paymentFromRepo = await _paymentRepository.RetrieveById(paymentId);
            _mapper.Map(paymentForUpdateDto, paymentFromRepo);

            if (await _unitOfWorkRepository.SaveChanges() > 0)
            {
                return NoContent();
            }

            throw new Exception($"Update Payment {paymentId} failed on save.");
        }

        [HttpGet]
        [Route("GetPaymentsForUser")]
        public async Task<IActionResult> GetPaymentsForUser(int userId)
        {
            var paymentsFromRepo = await _paymentRepository.GetPaymentsForUser(userId);
            var paymentsToReturnDto = _mapper.Map<IList<PaymentToReturnDto>>(paymentsFromRepo);

            return Ok(paymentsToReturnDto);
        }

        [HttpPost]
        [Route("CreatePayment")]
        public async Task<IActionResult> CreatePayment(int userId, PaymentForCreationDto paymentForCreationDto)
        {
            var payment = _mapper.Map<Payment>(paymentForCreationDto);
            await _paymentRepository.Add(payment);
            
            if (await _unitOfWorkRepository.SaveChanges() > 0)
            {
                payment.Category = await _categoryRepository.RetrieveById(payment.CategoryId);
                var paymentToReturn = _mapper.Map<PaymentToReturnDto>(payment);
                return CreatedAtAction(nameof(GetPayment),
                    new { paymentId = payment.Id, userId }, paymentToReturn);
            }

            throw new Exception("Creating payment failed on save.");
        }
    }
}