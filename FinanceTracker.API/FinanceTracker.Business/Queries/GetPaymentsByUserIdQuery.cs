using FinanceTracker.Business.Dtos;
using MediatR;
using System.Collections.Generic;

namespace FinanceTracker.Business.Queries
{
    public class GetPaymentsByUserIdQuery : IRequest<List<PaymentToReturnDto>>
    {
        public int UserId { get; }
        public GetPaymentsByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
