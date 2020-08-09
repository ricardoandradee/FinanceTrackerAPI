using FinanceTracker.Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [Route("api/financetracker")]
    public class FinanceTrackerController : ApiController
    {
        [HttpGet("GetListOfCurrency")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 1440)]
        public async Task<IActionResult> GetListOfCurrency()
        {
            var query = new GetListOfCurrencyQuery();
            var result = await Mediator.Send(query);
            return result == null ? (IActionResult)NotFound() : Ok(result);
        }

        [HttpGet("GetListOfTimeZone")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 1440)]
        public async Task<IActionResult> GetListOfTimeZone()
        {
            var query = new GetListOfStateTimeZoneQuery();
            var result = await Mediator.Send(query);
            return result == null ? (IActionResult)NotFound() : Ok(result);
        }
    }
}