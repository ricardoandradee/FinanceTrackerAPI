using FinanceTracker.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
