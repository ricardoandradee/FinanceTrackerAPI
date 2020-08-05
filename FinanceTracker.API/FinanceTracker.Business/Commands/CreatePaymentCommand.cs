using FinanceTracker.Business.Dtos;
using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class CreatePaymentCommand : IRequest<PaymentToReturnDto>
    {
        public PaymentForCreationDto PaymentForCreationDto { get; }
        public CreatePaymentCommand(PaymentForCreationDto paymentForCreationDto)
        {
            PaymentForCreationDto = paymentForCreationDto;
        }
    }
}
