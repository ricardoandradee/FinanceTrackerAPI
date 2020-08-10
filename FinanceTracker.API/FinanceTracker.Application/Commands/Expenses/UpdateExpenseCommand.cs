using AutoMapper;
using FinanceTracker.Application.Common.Exceptions;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Expenses;
using FinanceTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Expenses
{
    public class UpdateExpenseCommand : IRequest<bool>
    {
        public int ExpenseId { get; }
        public ExpenseForUpdateDto ExpenseForUpdateDto { get; }
        public UpdateExpenseCommand(int expenseId, ExpenseForUpdateDto expenseForUpdateDto)
        {
            ExpenseForUpdateDto = expenseForUpdateDto;
            ExpenseId = expenseId;
        }

        public class UpdateExpenseHandler : IRequestHandler<UpdateExpenseCommand, bool>
        {
            private readonly IExpenseRepository _expenseRepository;
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private readonly IMapper _mapper;

            public UpdateExpenseHandler(IExpenseRepository expenseRepository,
                IMapper mapper, IUnitOfWorkRepository unitOfWorkRepository)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
                _expenseRepository = expenseRepository;
            }

            public async Task<bool> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
            {
                var expenseFromRepo = await _expenseRepository.RetrieveById(request.ExpenseId);

                if (expenseFromRepo == null)
                {
                    throw new NotFoundException(nameof(Expense), request.ExpenseId);
                }

                _mapper.Map(request.ExpenseForUpdateDto, expenseFromRepo);
                return await _unitOfWorkRepository.SaveChanges() > 0;
            }
        }
    }
}
