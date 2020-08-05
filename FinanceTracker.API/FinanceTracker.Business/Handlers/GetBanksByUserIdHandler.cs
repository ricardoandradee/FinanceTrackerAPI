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
    public class GetBanksByUserIdHandler : IRequestHandler<GetBanksByUserIdQuery, List<BankToReturnDto>>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public GetBanksByUserIdHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
        }

        public async Task<List<BankToReturnDto>> Handle(GetBanksByUserIdQuery request, CancellationToken cancellationToken)
        {
            var banksFromRepo = await _bankRepository.GetBanksByUserId(request.UserId);
            return _mapper.Map<List<BankToReturnDto>>(banksFromRepo);
        }
    }
}
