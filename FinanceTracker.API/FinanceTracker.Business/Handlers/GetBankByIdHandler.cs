using AutoMapper;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Queries;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
    public class GetBankByIdHandler : IRequestHandler<GetBankByIdQuery, BankToReturnDto>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public GetBankByIdHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
        }

        public async Task<BankToReturnDto> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
        {
            var bankFromRepo = await _bankRepository.RetrieveById(request.BankId);
            return _mapper.Map<BankToReturnDto>(bankFromRepo);
        }
    }
}
