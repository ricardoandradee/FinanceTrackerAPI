using FinanceTracker.Application.Common.Exceptions;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Expenses
{
    public class DeleteExpenseCommand : IRequest<bool>
    {
        public int ExpenseId { get; }
        public DeleteExpenseCommand(int expenseId)
        {
            ExpenseId = expenseId;
        }

        public class DeleteExpenseHandler : IRequestHandler<DeleteExpenseCommand, bool>
        {
            private readonly IExpenseRepository _expenseRepository;
            private readonly ITransactionRepository _transactionRepository;
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;

            public DeleteExpenseHandler(IExpenseRepository expenseRepository,
                                        ITransactionRepository transactionRepository,
                                        IUnitOfWorkRepository unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _expenseRepository = expenseRepository;
                _transactionRepository = transactionRepository;
            }

            public async Task<bool> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
            {
                var expenseFromRepo = await _expenseRepository.RetrieveById(request.ExpenseId);

                if (expenseFromRepo == null)
                {
                    throw new NotFoundException(nameof(Expense), request.ExpenseId);
                }

                if (expenseFromRepo.TransactionId.HasValue)
                {
                    var transaction = await _unitOfWorkRepository.Context.Transactions.FindAsync(expenseFromRepo.TransactionId);
                    var account = await _unitOfWorkRepository.Context.Accounts.FindAsync(transaction.AccountId);
                    account.CurrentBalance += transaction.Amount;
                    _transactionRepository.Delete(transaction);
                }

                _expenseRepository.Delete(expenseFromRepo);

                return await _unitOfWorkRepository.SaveChanges() > 0;
            }
        }
    }
}
