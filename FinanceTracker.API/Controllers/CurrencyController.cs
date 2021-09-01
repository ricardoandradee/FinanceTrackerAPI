using FinanceTracker.Application.Queries.Currencies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [Route("api/currency")]
    public class CurrencyController : ApiController
    {
        [Authorize]
        [HttpGet("GetListOfRates")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 1440)]
        public async Task<IActionResult> GetListOfRates()
        {
            var query = new GetListOfRatesQuery();
            var result = await Mediator.Send(query);
            return string.IsNullOrWhiteSpace(result) ? (IActionResult) NotFound() : Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("GetListOfCurrencies")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 1440)]
        public async Task<IActionResult> GetListOfCurrencies()
        {
            var query = new GetListOfCurrenciesQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}