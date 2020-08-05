using FinanceTracker.Business.Dtos;
using MediatR;

namespace FinanceTracker.Business.Queries
{
    public class GetTransactionByIdQuery : IRequest<TransactionToReturnDto>
    {
        public int TransactionId { get; }
        public GetTransactionByIdQuery(int transactionId)
        {
            TransactionId = transactionId;
        }
    }
}
