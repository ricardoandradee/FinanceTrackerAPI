using FinanceTracker.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Repositories.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<IList<Payment>> GetPaymentsByUserId(int userId);
        Task<bool> BelongsToUser(int userId, int paymentId);
    }
}
