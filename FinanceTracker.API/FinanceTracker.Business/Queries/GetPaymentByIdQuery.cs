using FinanceTracker.Business.Dtos;
using MediatR;

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
