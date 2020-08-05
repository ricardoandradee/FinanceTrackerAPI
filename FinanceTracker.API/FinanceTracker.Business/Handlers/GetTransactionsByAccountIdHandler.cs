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
    public class GetTransactionsByAccountIdHandler : IRequestHandler<GetTransactionsByAccountIdQuery, List<TransactionToReturnDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionsByAccountIdHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<List<TransactionToReturnDto>> Handle(GetTransactionsByAccountIdQuery request, CancellationToken cancellationToken)
        {
            var transactionsFromRepo = await _transactionRepository.GetTransactionsByAccountId(request.AccountId);
            return _mapper.Map<List<TransactionToReturnDto>>(transactionsFromRepo);
        }
    }
}
