using AutoMapper;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Models;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Commands
{
    public class CreateAccountCommand : IRequest<AccountToReturnDto>
    {
        public AccountForCreationDto AccountForCreationDto { get; }
        public CreateAccountCommand(AccountForCreationDto accountForCreationDto)
        {
            AccountForCreationDto = accountForCreationDto;
        }

        public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, AccountToReturnDto>
        {
            private readonly IAccountRepository _accountRepository;
            private readonly IMapper _mapper;

            public CreateAccountHandler(IAccountRepository accountRepository, IMapper mapper)
            {
                _mapper = mapper;
                _accountRepository = accountRepository;
            }

            public async Task<AccountToReturnDto> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
            {
                var accountToBeCreated = _mapper.Map<Account>(request.AccountForCreationDto);
                var createdAccount = await _accountRepository.CreateAccount(accountToBeCreated);
                return _mapper.Map<AccountToReturnDto>(createdAccount);
            }
        }
    }
}
