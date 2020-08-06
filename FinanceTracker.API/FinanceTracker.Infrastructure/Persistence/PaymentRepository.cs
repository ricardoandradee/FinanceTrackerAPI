using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Persistence
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IUnitOfWorkRepository unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<IList<Payment>> GetPaymentsByUserId(int userId)
        {
            var payments = await _unitOfWork.Context.Payments.Where(b => b.Category.User.Id == userId)
                .Include(c => c.Category)
                .ToListAsync();

            return payments;
        }

        public async Task<bool> BelongsToUser(int userId, int paymentId)
        {
            return await _unitOfWork.Context.Payments.AnyAsync(b => b.Id == paymentId && b.Category.User.Id == userId);
        }
    }
}
