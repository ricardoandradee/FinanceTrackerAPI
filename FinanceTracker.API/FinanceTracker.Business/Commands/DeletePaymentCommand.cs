using FinanceTracker.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
