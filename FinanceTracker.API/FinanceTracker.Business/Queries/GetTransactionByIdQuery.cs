using AutoMapper;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Queries
{
    public class GetTransactionByIdQuery : IRequest<TransactionToReturnDto>
    {
        public int TransactionId { get; }
        public GetTransactionByIdQuery(int transactionId)
        {
            TransactionId = transactionId;
        }

        public class GetTransactionByIdHandler : IRequestHandler<GetTransactionByIdQuery, TransactionToReturnDto>
        {
            private readonly ITransactionRepository _transactionRepository;
            private readonly IMapper _mapper;

            public GetTransactionByIdHandler(ITransactionRepository transactionRepository, IMapper mapper)
            {
                _mapper = mapper;
                _transactionRepository = transactionRepository;
            }

            public async Task<TransactionToReturnDto> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
            {
                var transactionFromRepo = await _transactionRepository.RetrieveById(request.TransactionId);
                return _mapper.Map<TransactionToReturnDto>(transactionFromRepo);
            }
        }
    }
}
