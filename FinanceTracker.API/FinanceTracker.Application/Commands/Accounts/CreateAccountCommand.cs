using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos;
using FinanceTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Accounts
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
