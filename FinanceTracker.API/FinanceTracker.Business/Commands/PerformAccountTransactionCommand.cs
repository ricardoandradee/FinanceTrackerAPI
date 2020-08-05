using FinanceTracker.Business.Dtos;
using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class PerformAccountTransactionCommand : IRequest<TransactionToReturnDto>
    {
        public TransactionForCreationDto TransactionForCreationDto { get; }
        public PerformAccountTransactionCommand(TransactionForCreationDto transactionForCreationDtoo)
        {
            TransactionForCreationDto = transactionForCreationDtoo;
        }
    }
}
