using FinanceTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<IList<Payment>> GetPaymentsByUserId(int userId);
        Task<bool> BelongsToUser(int userId, int paymentId);
    }
}
