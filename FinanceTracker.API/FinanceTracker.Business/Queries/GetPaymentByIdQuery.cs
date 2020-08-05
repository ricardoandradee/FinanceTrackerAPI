using FinanceTracker.Business.Dtos;
using MediatR;
using System.Collections.Generic;

namespace FinanceTracker.Business.Queries
{
    public class GetPaymentByIdQuery : IRequest<PaymentToReturnDto>
    {
        public int PaymentId { get; }
        public GetPaymentByIdQuery(int paymentId)
        {
            PaymentId = paymentId;
        }
    }
}
