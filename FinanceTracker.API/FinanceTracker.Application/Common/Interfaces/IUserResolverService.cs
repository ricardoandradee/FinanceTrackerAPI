using System.Security.Claims;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IUserResolverService
    {
        ClaimsPrincipal GetUserClaimsPrincipal();
    }
}
