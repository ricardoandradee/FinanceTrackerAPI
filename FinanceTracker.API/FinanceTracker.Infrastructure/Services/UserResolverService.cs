using FinanceTracker.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinanceTracker.Infrastructure.Services
{
    public class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserResolverService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal GetUserClaimsPrincipal()
        {
            var userClaimsPrincipal = _httpContextAccessor?.HttpContext?.User;
            return userClaimsPrincipal;
        }
    }
}
