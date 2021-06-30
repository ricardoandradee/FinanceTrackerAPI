using FinanceTracker.Application.Commands.Expenses.UserLoginHistories;
using FinanceTracker.Application.Dtos.UserLoginHistories;
using FinanceTracker.Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [Route("api/financetracker")]
    public class FinanceTrackerController : ApiController
    {
        [HttpGet]
        [Route("GetListOfCurrency")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 1440)]
        public async Task<IActionResult> GetListOfCurrency()
        {
            var query = new GetListOfCurrencyQuery();
            var result = await Mediator.Send(query);
            return result == null ? (IActionResult)NotFound() : Ok(result);
        }

        [HttpGet]
        [Route("GetListOfTimeZone")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 1440)]
        public async Task<IActionResult> GetListOfTimeZone()
        {
            var query = new GetListOfStateTimeZoneQuery();
            var result = await Mediator.Send(query);
            return result == null ? (IActionResult)NotFound() : Ok(result);
        }


        [HttpPost]
        [Route("CreateUserLoginHistory")]
        public async Task<IActionResult> CreateUserLoginHistory(UserLoginHistoryForCreationDto userLoginHistoryForCreationDto)
        {
            var command = new CreateUserLoginHistoryCommand(userLoginHistoryForCreationDto);
            var result = await Mediator.Send(command);
            return result > 0 ? (IActionResult)Ok() : BadRequest();
        }
    }
}