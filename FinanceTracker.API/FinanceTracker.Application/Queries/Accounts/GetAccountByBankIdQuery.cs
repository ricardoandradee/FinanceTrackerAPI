using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Accounts
{
    public class GetAccountByBankIdQuery : IRequest<List<AccountToReturnDto>>
    {
        public int BankId { get; }
        public GetAccountByBankIdQuery(int bankId)
        {
            BankId = bankId;
        }

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
}
