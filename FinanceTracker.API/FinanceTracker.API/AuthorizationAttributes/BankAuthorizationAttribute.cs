using FinanceTracker.Business.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace FinanceTracker.API.AuthorizationAttributes
{
    public sealed class BankAuthorizationAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly IBankRepository _bankRepository;
        public BankAuthorizationAttribute(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var isUserAuthorized = false;

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = context.RouteData.Values["userId"].ToString(); 
                var bankId = context.RouteData.Values["bankId"].ToString();

                if (int.TryParse(userId, out int userIdParsed)
                    && int.TryParse(bankId, out int bankIdParsed))
                {
                    isUserAuthorized = await _bankRepository.BelongsToUser(userIdParsed, bankIdParsed);
                }
            }
            
            if (!isUserAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
