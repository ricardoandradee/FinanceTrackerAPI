using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceTracker.API.Data;
using FinanceTracker.API.Models;
using FinanceTracker.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.API.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DataContext context)
            : base(context)
        {
        }

        public async Task<IList<Payment>> GetPaymentsForUser(int userId)
        {
            var payments = await _context.Payments.Where(b => b.Category.User.Id == userId)
                .Include(c => c.Category)
                .ToListAsync();

            return payments;
        }

        public async Task<bool> PaymentBelongsToUser(int userId, int paymentId)
        {
            return await _context.Payments.AnyAsync(b => b.Id == paymentId && b.Category.User.Id == userId);
        }
    }
}
