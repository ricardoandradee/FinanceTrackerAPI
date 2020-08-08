using FinanceTracker.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FinanceTracker.API.AuthorizationAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class UserAuthorizationAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isUserAuthorized = false;

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = context.RouteData.Values["userId"].ToString();            
                isUserAuthorized = context.HttpContext.User.IsCurrentUser(userId);
            }
            
            if (!isUserAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
