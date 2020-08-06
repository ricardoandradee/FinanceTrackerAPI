using AutoMapper;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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
