using MediatR;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Users
{
    public class GetListOfRatesQuery : IRequest<string>
    {
        public GetListOfRatesQuery()
        {
        }

        public class GetListOfCurrenciesHandler : IRequestHandler<GetListOfRatesQuery, string>
        {
            public async Task<string> Handle(GetListOfRatesQuery request, CancellationToken cancellationToken)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpResponseMessage response = await client.GetAsync(
                        $"http://data.fixer.io/api/{DateTime.UtcNow.ToString("yyyy-MM-dd")}?access_key=64331659be802cac357a58afd15be63e&format=1");
                    return response.IsSuccessStatusCode ? response.Content.ReadAsStringAsync().Result : string.Empty;
                }
            }
        }
    }
}
