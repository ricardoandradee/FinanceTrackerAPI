using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class DeleteBankInfoCommand : IRequest<bool>
    {
        public int BankId { get; }
        public DeleteBankInfoCommand(int bankId)
        {
            BankId = bankId;
        }
    }
}
