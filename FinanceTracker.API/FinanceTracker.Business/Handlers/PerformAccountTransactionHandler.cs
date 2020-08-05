using AutoMapper;
using FinanceTracker.Business.Commands;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Models;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
    public class PerformAccountTransactionHandler : IRequestHandler<PerformAccountTransactionCommand, TransactionToReturnDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public PerformAccountTransactionHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionToReturnDto> Handle(PerformAccountTransactionCommand request, CancellationToken cancellationToken)
        {
            var transactionOptions = new string[] { "Deposit", "Withdraw" };
            if (request.TransactionForCreationDto.Amount <= 0 ||
                !transactionOptions.Contains(request.TransactionForCreationDto.Action))
            {
                return null;
            }

            var transactionToCreate = _mapper.Map<Transaction>(request.TransactionForCreationDto);
            var transactionCreated = await _transactionRepository.PerformAccountTransaction(transactionToCreate);
            return _mapper.Map<TransactionToReturnDto>(transactionCreated);
        }
    }
}
