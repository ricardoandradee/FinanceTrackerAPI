using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Expenses;
using FinanceTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Expenses
{
    public class CreateExpenseCommand : IRequest<ExpenseToReturnDto>
    {
        public ExpenseForCreationDto ExpenseForCreationDto { get; }
        public CreateExpenseCommand(ExpenseForCreationDto expenseForCreationDto)
        {
            ExpenseForCreationDto = expenseForCreationDto;
        }

        public class CreateExpenseHandler : IRequestHandler<CreateExpenseCommand, ExpenseToReturnDto>
        {
            private readonly IExpenseRepository _expenseRepository;
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private readonly IMapper _mapper;

            public CreateExpenseHandler(IExpenseRepository expenseRepository,
                IMapper mapper, IUnitOfWorkRepository unitOfWorkRepository)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
                _expenseRepository = expenseRepository;
            }

            public async Task<ExpenseToReturnDto> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
            {
                var expense = _mapper.Map<Expense>(request.ExpenseForCreationDto);
                await _expenseRepository.Add(expense);

                if (await _unitOfWorkRepository.SaveChanges() > 0)
                {
                    expense.Category = await _unitOfWorkRepository.Context.Categories.FindAsync(expense.CategoryId);
                    expense.Currency = await _unitOfWorkRepository.Context.Currencies.FindAsync(expense.CurrencyId);
                    return _mapper.Map<ExpenseToReturnDto>(expense);
                }

                return null;
            }
        }
    }
}
