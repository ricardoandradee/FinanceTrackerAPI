using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Banks;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Banks
{
    public class GetBanksByUserIdQuery : IRequest<List<BankToReturnDto>>
    {
        public int UserId { get; }
        public GetBanksByUserIdQuery(int userId)
        {
            UserId = userId;
        }

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
}
