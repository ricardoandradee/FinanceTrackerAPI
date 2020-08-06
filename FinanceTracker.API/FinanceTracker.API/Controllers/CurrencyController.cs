using FinanceTracker.Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/currency")]
    public class CurrencyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CurrencyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetListOfCurrencies")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 1440)]
        public async Task<IActionResult> GetListOfCurrencies()
        {
            var query = new GetListOfCurrenciesQuery();
            var result = await _mediator.Send(query);
            return string.IsNullOrWhiteSpace(result) ? (IActionResult) NotFound() : Ok(result);
        }
    }
}