using FinanceTracker.Business.Dtos;
using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class CreateAccountCommand : IRequest<AccountToReturnDto>
    {
        public AccountForCreationDto AccountForCreationDto { get; }
        public CreateAccountCommand(AccountForCreationDto accountForCreationDto)
        {
            AccountForCreationDto = accountForCreationDto;
        }
    }
}
