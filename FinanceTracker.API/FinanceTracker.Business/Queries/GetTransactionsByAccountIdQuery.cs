using FinanceTracker.Business.Dtos;
using MediatR;
using System.Collections.Generic;

namespace FinanceTracker.Business.Queries
{
    public class GetTransactionsByAccountIdQuery : IRequest<List<TransactionToReturnDto>>
    {
        public int AccountId { get; }
        public GetTransactionsByAccountIdQuery(int accountId)
        {
            AccountId = accountId;
        }
    }
}
