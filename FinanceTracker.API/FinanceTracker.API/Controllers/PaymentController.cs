using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Application.Commands.Payments;
using FinanceTracker.Application.Dtos;
using FinanceTracker.Application.Dtos.Payments;
using FinanceTracker.Application.Queries.Payments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [UserAuthorization]
    [Route("api/user/{userId}/payment")]
    public class PaymentController : ApiController
    {
        [HttpGet]
        [Route("GetPaymentById/{paymentId}")]
        [TypeFilter(typeof(PaymentAuthorizationAttribute))]
        public async Task<IActionResult> GetPaymentById(int paymentId)
        {
            var query = new GetPaymentByIdQuery(paymentId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("GetPaymentsByUserId")]
        public async Task<IActionResult> GetPaymentsByUserId(int userId)
        {
            var query = new GetPaymentsByUserIdQuery(userId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpDelete]
        [Route("DeletePayment/{paymentId}")]
        [TypeFilter(typeof(PaymentAuthorizationAttribute))]
        public async Task<IActionResult> DeletePayment(int paymentId)
        {
            var command = new DeletePaymentCommand(paymentId);
            var result = await Mediator.Send(command);

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
            var result = await Mediator.Send(command);

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
            var result = await Mediator.Send(command);
            
            if (result != null)
            {
                return CreatedAtAction(nameof(GetPaymentById),
                    new { paymentId = result.Id, userId }, result);
            }

            throw new Exception("Creating payment failed on save.");
        }
    }
}