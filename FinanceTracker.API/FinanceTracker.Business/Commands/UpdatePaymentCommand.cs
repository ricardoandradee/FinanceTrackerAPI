using FinanceTracker.Business.Dtos;
using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class UpdatePaymentCommand : IRequest<bool>
    {
        public int PaymentId { get; }
        public PaymentForUpdateDto PaymentForUpdateDto { get; }
        public UpdatePaymentCommand(int paymentId, PaymentForUpdateDto paymentForUpdateDto)
        {
            PaymentForUpdateDto = paymentForUpdateDto;
            PaymentId = paymentId;
        }
    }
}
