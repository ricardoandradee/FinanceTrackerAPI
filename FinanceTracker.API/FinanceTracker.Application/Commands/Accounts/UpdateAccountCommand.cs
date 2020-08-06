using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Accounts
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

        public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, bool>
        {
            private readonly IAccountRepository _accountRepository;
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private readonly IMapper _mapper;

            public UpdateAccountHandler(IAccountRepository accountRepository,
                IMapper mapper, IUnitOfWorkRepository unitOfWorkRepository)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
                _accountRepository = accountRepository;
            }

            public async Task<bool> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
            {
                var accountFromRepo = await _accountRepository.RetrieveById(request.AccountId);
                _mapper.Map(request.AccountForUpdateDto, accountFromRepo);
                return await _unitOfWorkRepository.SaveChanges() > 0;
            }
        }
    }
}
