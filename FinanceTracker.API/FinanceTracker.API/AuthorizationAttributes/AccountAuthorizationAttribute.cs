using FinanceTracker.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace FinanceTracker.API.AuthorizationAttributes
{
    public sealed class AccountAuthorizationAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly IAccountRepository _accountRepository;
        public AccountAuthorizationAttribute(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var isUserAuthorized = false;

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = context.RouteData.Values["userId"].ToString(); 
                var accountId = context.RouteData.Values["accountId"].ToString();

                if (int.TryParse(userId, out int userIdParsed)
                    && int.TryParse(accountId, out int accountIdParsed))
                {
                    isUserAuthorized = await _accountRepository.BelongsToUser(userIdParsed, accountIdParsed);
                }
            }
            
            if (!isUserAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
