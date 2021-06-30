using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Transactions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Transactions
{
    public class GetTransactionsByAccountIdQuery : IRequest<List<TransactionToReturnDto>>
    {
        public int AccountId { get; }
        public GetTransactionsByAccountIdQuery(int accountId)
        {
            AccountId = accountId;
        }

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
}
