using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Business.Commands;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [UserAuthorization]
    [Route("api/user/{userId}/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetPaymentById/{paymentId}")]
        [TypeFilter(typeof(PaymentAuthorizationAttribute))]
        public async Task<IActionResult> GetPaymentById(int paymentId)
        {
            var query = new GetPaymentByIdQuery(paymentId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("GetPaymentsByUserId")]
        public async Task<IActionResult> GetPaymentsByUserId(int userId)
        {
            var query = new GetPaymentsByUserIdQuery(userId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpDelete]
        [Route("DeletePayment/{paymentId}")]
        [TypeFilter(typeof(PaymentAuthorizationAttribute))]
        public async Task<IActionResult> DeletePayment(int paymentId)
        {
            var command = new DeletePaymentCommand(paymentId);
            var result = await _mediator.Send(command);

            if (result)
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
            var command = new UpdatePaymentCommand(paymentId, paymentForUpdateDto);
            var result = await _mediator.Send(command);

            if (result)
            {
                return NoContent();
            }

            throw new Exception($"Update Payment {paymentId} failed on save.");
        }

        [HttpPost]
        [Route("CreatePayment")]
        public async Task<IActionResult> CreatePayment(int userId, PaymentForCreationDto paymentForCreationDto)
        {
            var command = new CreatePaymentCommand(paymentForCreationDto);
            var result = await _mediator.Send(command);
            
            if (result != null)
            {
                return CreatedAtAction(nameof(GetPaymentById),
                    new { paymentId = result.Id, userId }, result);
            }

            throw new Exception("Creating payment failed on save.");
        }
    }
}