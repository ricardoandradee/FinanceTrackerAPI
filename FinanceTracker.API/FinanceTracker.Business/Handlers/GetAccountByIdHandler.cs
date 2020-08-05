using AutoMapper;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Queries;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
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
