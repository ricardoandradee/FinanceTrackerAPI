using FinanceTracker.Business.Dtos;
using MediatR;

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
