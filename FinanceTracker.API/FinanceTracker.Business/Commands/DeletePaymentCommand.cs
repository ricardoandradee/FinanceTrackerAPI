using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class DeletePaymentCommand : IRequest<bool>
    {
        public int PaymentId { get; }
        public DeletePaymentCommand(int paymentId)
        {
            PaymentId = paymentId;
        }
    }
}
