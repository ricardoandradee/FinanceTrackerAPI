using FinanceTracker.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.API.Repositories.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<IList<Payment>> GetPaymentsForUser(int userId);
        Task<bool> PaymentBelongsToUser(int userId, int paymentId);
    }
}
