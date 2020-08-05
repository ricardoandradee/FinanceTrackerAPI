using AutoMapper;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Queries;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
    public class GetAccountByBankIdHandler : IRequestHandler<GetAccountByBankIdQuery, List<AccountToReturnDto>>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public GetAccountByBankIdHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
        }

        public async Task<List<AccountToReturnDto>> Handle(GetAccountByBankIdQuery request, CancellationToken cancellationToken)
        {
            var accountsFromRepo = await _bankRepository.GetAllAccounts(request.BankId);
            return _mapper.Map<List<AccountToReturnDto>>(accountsFromRepo);
        }
    }
}
