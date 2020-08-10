using FinanceTracker.Application.Commands.Users;
using FinanceTracker.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Services
{
    public class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserResolverService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal GetUserClaimsPrincipal()
        {
            var userClaimsPrincipal = _httpContextAccessor?.HttpContext?.User;
            return userClaimsPrincipal;
        }

        public async Task<UserLocationDetailsDto> GetUsersLocation()
        {
            using (HttpClient client = new HttpClient())
            {
                string locationAsJSON = await SendRequestToJsonApi(client);
                return DeserializeLocationJson(locationAsJSON);
            }
        }

        private async Task<string> SendRequestToJsonApi(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.GetAsync($"https://ipinfo.io/");
            var locationAsJSON = response.IsSuccessStatusCode ? response.Content.ReadAsStringAsync().Result : string.Empty;
            return locationAsJSON;
        }

        private static UserLocationDetailsDto DeserializeLocationJson(string locationAsJSON)
        {
            return JsonConvert.DeserializeObject<UserLocationDetailsDto>(locationAsJSON);
        }
    }
}
