using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Expenses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Expenses
{
    public class GetExpensesByUserIdQuery : IRequest<List<ExpenseToReturnDto>>
    {
        public int UserId { get; }
        public GetExpensesByUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public class GetExpensesByUserIdHandler : IRequestHandler<GetExpensesByUserIdQuery, List<ExpenseToReturnDto>>
        {
            private readonly IExpenseRepository _expenseRepository;
            private readonly IMapper _mapper;

            public GetExpensesByUserIdHandler(IExpenseRepository expenseRepository, IMapper mapper)
            {
                _mapper = mapper;
                _expenseRepository = expenseRepository;
            }

            public async Task<List<ExpenseToReturnDto>> Handle(GetExpensesByUserIdQuery request, CancellationToken cancellationToken)
            {
                var expensesFromRepo = await _expenseRepository.GetExpensesByUserId(request.UserId);
                return _mapper.Map<List<ExpenseToReturnDto>>(expensesFromRepo);
            }
        }
    }
}
