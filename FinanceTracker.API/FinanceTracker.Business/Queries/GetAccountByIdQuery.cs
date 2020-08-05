using FinanceTracker.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Business.Queries
{
    public class GetAccountByIdQuery : IRequest<AccountToReturnDto>
    {
        public int AccountId { get; }
        public GetAccountByIdQuery(int accountId)
        {
            AccountId = accountId;
        }
    }
}
