using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Accounts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Accounts
{
    public class GetAccountByIdQuery : IRequest<AccountToReturnDto>
    {
        public int AccountId { get; }
        public GetAccountByIdQuery(int accountId)
        {
            AccountId = accountId;
        }

        public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, AccountToReturnDto>
        {
            private readonly IAccountRepository _accountRepository;
            private readonly IMapper _mapper;

            public GetAccountByIdHandler(IAccountRepository accountRepository, IMapper mapper)
            {
                _mapper = mapper;
                _accountRepository = accountRepository;
            }

            public async Task<AccountToReturnDto> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
            {
                var accountFromRepo = await _accountRepository.RetrieveById(request.AccountId);
                return _mapper.Map<AccountToReturnDto>(accountFromRepo);
            }
        }
    }
}
