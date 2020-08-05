using FinanceTracker.Business.Dtos;
using MediatR;
using System.Collections.Generic;

namespace FinanceTracker.Business.Queries
{
    public class GetBanksByUserIdQuery : IRequest<List<BankToReturnDto>>
    {
        public int UserId { get; }
        public GetBanksByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
