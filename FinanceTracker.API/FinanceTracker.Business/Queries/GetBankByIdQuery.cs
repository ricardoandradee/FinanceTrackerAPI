using FinanceTracker.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Business.Queries
{
    public class GetBankByIdQuery : IRequest<BankToReturnDto>
    {
        public int BankId { get; }
        public GetBankByIdQuery(int bankId)
        {
            BankId = bankId;
        }
    }
}
