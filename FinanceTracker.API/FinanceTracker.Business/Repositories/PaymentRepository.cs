using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceTracker.Business.Data;
using FinanceTracker.Business.Models;
using FinanceTracker.Business.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Business.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IUnitOfWorkRepository unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<IList<Payment>> GetPaymentsForUser(int userId)
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
