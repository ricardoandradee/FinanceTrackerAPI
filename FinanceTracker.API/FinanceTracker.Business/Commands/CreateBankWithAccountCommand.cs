using FinanceTracker.Business.Dtos;
using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class CreateBankWithAccountCommand : IRequest<BankToReturnDto>
    {
        public BankForCreationDto BankForCreationDto { get; }
        public CreateBankWithAccountCommand(BankForCreationDto bankForCreationDto)
        {
            BankForCreationDto = bankForCreationDto;
        }
    }
}
