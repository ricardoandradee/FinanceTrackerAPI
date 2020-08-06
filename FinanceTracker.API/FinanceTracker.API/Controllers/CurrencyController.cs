using FinanceTracker.Application.Queries.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [Authorize]
    [Route("api/currency")]
    public class CurrencyController : ApiController
    {
        [HttpGet("GetListOfCurrencies")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 1440)]
        public async Task<IActionResult> GetListOfCurrencies()
        {
            var query = new GetListOfCurrenciesQuery();
            var result = await Mediator.Send(query);
            return string.IsNullOrWhiteSpace(result) ? (IActionResult) NotFound() : Ok(result);
        }
    }
}