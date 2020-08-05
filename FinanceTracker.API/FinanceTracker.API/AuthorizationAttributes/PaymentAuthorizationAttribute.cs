using FinanceTracker.Business.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace FinanceTracker.API.AuthorizationAttributes
{
    public sealed class PaymentAuthorizationAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentAuthorizationAttribute(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var isUserAuthorized = false;

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = context.RouteData.Values["userId"].ToString(); 
                var paymentId = context.RouteData.Values["paymentId"].ToString();

                if (int.TryParse(userId, out int userIdParsed)
                    && int.TryParse(paymentId, out int paymentIdParsed))
                {
                    isUserAuthorized = await _paymentRepository.BelongsToUser(userIdParsed, paymentIdParsed);
                }
            }
            
            if (!isUserAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
