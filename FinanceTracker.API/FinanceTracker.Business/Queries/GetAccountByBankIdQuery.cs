using FinanceTracker.Business.Dtos;
using MediatR;
using System.Collections.Generic;

namespace FinanceTracker.Business.Queries
{
    public class GetAccountByBankIdQuery : IRequest<List<AccountToReturnDto>>
    {
        public int BankId { get; }
        public GetAccountByBankIdQuery(int bankId)
        {
            BankId = bankId;
        }
    }
}
