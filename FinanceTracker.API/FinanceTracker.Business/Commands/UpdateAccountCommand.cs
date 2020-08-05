using FinanceTracker.Business.Dtos;
using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class UpdateAccountCommand : IRequest<bool>
    {
        public int AccountId { get; }
        public AccountForUpdateDto AccountForUpdateDto { get; }
        public UpdateAccountCommand(AccountForUpdateDto accountForUpdateDto, int accountId)
        {
            AccountId = accountId;
            AccountForUpdateDto = accountForUpdateDto;
        }
    }
}
