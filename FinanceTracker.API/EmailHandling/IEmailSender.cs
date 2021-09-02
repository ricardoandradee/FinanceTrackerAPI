using FinanceTracker.Application.Common.Models;
using System.Threading.Tasks;

namespace FinanceTracker.API.EmailHandling
{
    public interface IEmailSender
    {
        Task<Response<string>> SendVerificationEmail(UserEmailDto emailDetails);
    }
}