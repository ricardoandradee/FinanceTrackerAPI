using FinanceTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IPaymentRepository : IUserVerification, IRepository<Payment>
    {
        Task<IList<Payment>> GetPaymentsByUserId(int userId);
    }
}
