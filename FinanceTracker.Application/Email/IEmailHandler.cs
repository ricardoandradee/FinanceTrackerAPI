using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Email;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Email
{
    public interface IEmailHandler
    {
        Task<Response<string>> SendEmail(UserEmailDto userEmailDto, EmailDetailsDto emailDetailsDto);
    }
}