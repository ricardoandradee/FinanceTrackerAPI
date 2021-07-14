using AutoMapper;
using FinanceTracker.Application.Common.Exceptions;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Expenses;
using FinanceTracker.Application.Dtos.Transactions;
using FinanceTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Expenses
{
    public class UpdateExpenseCommand : IRequest<TransactionToReturnDto>
    {
        public int ExpenseId { get; }
        public ExpenseForUpdateDto ExpenseForUpdateDto { get; }
        public UpdateExpenseCommand(int expenseId, ExpenseForUpdateDto expenseForUpdateDto)
        {
            ExpenseForUpdateDto = expenseForUpdateDto;
            ExpenseId = expenseId;
        }

        public class UpdateExpenseHandler : IRequestHandler<UpdateExpenseCommand, TransactionToReturnDto>
        {
            private readonly IExpenseRepository _expenseRepository;
            private readonly IAccountRepository _accountRepository;
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private readonly IMapper _mapper;

            public UpdateExpenseHandler(IExpenseRepository expenseRepository,
                IMapper mapper, IUnitOfWorkRepository unitOfWorkRepository,
                IAccountRepository accountRepository)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
                _expenseRepository = expenseRepository;
                _accountRepository = accountRepository;
            }

            public async Task<TransactionToReturnDto> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
            {
                var expenseFromRepo = await _expenseRepository.RetrieveById(request.ExpenseId);

                if (expenseFromRepo == null)
                {
                    throw new NotFoundException(nameof(Expense), request.ExpenseId);
                }

                _mapper.Map(request.ExpenseForUpdateDto, expenseFromRepo);
                
                var transaction = _mapper.Map<Transaction>(request.ExpenseForUpdateDto.Transaction);
                if (transaction != null) {
                    var accountFromRepo = await _accountRepository.RetrieveById(transaction.AccountId);
                    accountFromRepo.CurrentBalance -= transaction.Amount;
                    transaction.BalanceAfterTransaction = accountFromRepo.CurrentBalance;
                }
                
                expenseFromRepo.Transaction = transaction;

                
                if (await _unitOfWorkRepository.SaveChanges() > 0)
                {
                    var transactionToReturn = _mapper.Map<TransactionToReturnDto>(transaction);
                    return transactionToReturn;
                }

                return null;
            }
        }
    }
}
