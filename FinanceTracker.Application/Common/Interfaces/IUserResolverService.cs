using FinanceTracker.Application.Commands.Users;
using FinanceTracker.Application.Dtos.Users;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IUserResolverService
    {
        ClaimsPrincipal GetUserClaimsPrincipal();
        Task<UserLocationDetailsDto> GetUsersLocation();
    }
}
