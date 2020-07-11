using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/currency")]
    public class CurrencyController : ControllerBase
    {
        public CurrencyController()
        {
        }

        [HttpGet("GetListOfCurrencies")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 1440)]
        public async Task<IActionResult> GetListOfCurrencies()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpResponseMessage response = await client.GetAsync($"http://data.fixer.io/api/{DateTime.UtcNow.ToString("yyyy-MM-dd")}?access_key=64331659be802cac357a58afd15be63e&format=1");
                    
                    if (response.IsSuccessStatusCode)
                    {
                        var readAsStringAsync = response.Content.ReadAsStringAsync();
                        return Ok(readAsStringAsync.Result);
                    }
                    else
                    {
                        return BadRequest("There was an error while trying to fatch currency list.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}