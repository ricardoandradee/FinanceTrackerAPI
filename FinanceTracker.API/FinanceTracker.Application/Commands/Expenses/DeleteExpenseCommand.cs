using FinanceTracker.Application.Common.Interfaces;
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
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;

            public DeleteExpenseHandler(IExpenseRepository expenseRepository, IUnitOfWorkRepository unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _expenseRepository = expenseRepository;
            }

            public async Task<bool> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
            {
                var expenseFromRepo = await _expenseRepository.RetrieveById(request.ExpenseId);
                _expenseRepository.Delete(expenseFromRepo);

                return await _unitOfWorkRepository.SaveChanges() > 0;
            }
        }
    }
}
