using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class DeleteAccountCommand : IRequest<bool>
    {
        public int AccountId { get; }
        public DeleteAccountCommand(int accountId)
        {
            AccountId = accountId;
        }
    }
}
