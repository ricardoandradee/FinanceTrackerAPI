using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Application.Commands.Expenses;
using FinanceTracker.Application.Dtos.Expenses;
using FinanceTracker.Application.Queries.Expenses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [UserAuthorization]
    [Route("api/user/{userId}/expense")]
    public class ExpenseController : ApiController
    {
        [HttpGet]
        [Route("GetExpenseById/{expenseId}")]
        public async Task<IActionResult> GetExpenseById(int expenseId)
        {
            var query = new GetExpenseByIdQuery(expenseId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("GetExpensesByUserId")]
        public async Task<IActionResult> GetExpensesByUserId(int userId)
        {
            var query = new GetExpensesByUserIdQuery(userId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpDelete]
        [Route("DeleteExpense/{expenseId}")]
        public async Task<IActionResult> DeleteExpense(int expenseId)
        {
            var command = new DeleteExpenseCommand(expenseId);
            var result = await Mediator.Send(command);

            if (result)
            {
                return NoContent();
            }

            throw new Exception("Error deleting the expense.");
        }

        [HttpPut]
        [Route("UpdateExpense/{expenseId}")]
        public async Task<IActionResult> UpdateExpense(int expenseId, ExpenseForUpdateDto expenseForUpdateDto)
        {
            var command = new UpdateExpenseCommand(expenseId, expenseForUpdateDto);
            var result = await Mediator.Send(command);

            if (result)
            {
                return NoContent();
            }

            throw new Exception($"Update Expense {expenseId} failed on save.");
        }

        [HttpPost]
        [Route("CreateExpense")]
        public async Task<IActionResult> CreateExpense(int userId, ExpenseForCreationDto expenseForCreationDto)
        {
            var command = new CreateExpenseCommand(expenseForCreationDto);
            var result = await Mediator.Send(command);
            
            if (result != null)
            {
                return CreatedAtAction(nameof(GetExpenseById),
                    new { expenseId = result.Id, userId }, result);
            }

            throw new Exception("Creating expense failed on save.");
        }
    }
}