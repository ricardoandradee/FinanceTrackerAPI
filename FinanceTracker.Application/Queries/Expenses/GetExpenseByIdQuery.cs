using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Expenses;

namespace FinanceTracker.Application.Queries.Expenses
{
    public class GetExpenseByIdQuery : IRequest<ExpenseToReturnDto>
    {
        public int ExpenseId { get; }

        public GetExpenseByIdQuery(int expenseId)
        {
            ExpenseId = expenseId;
        }

        public class GetExpenseByIdHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseToReturnDto>
        {
            private readonly IExpenseRepository _expenseRepository;
            private readonly IMapper _mapper;

            public GetExpenseByIdHandler(IExpenseRepository expenseRepository, IMapper mapper)
            {
                _mapper = mapper;
                _expenseRepository = expenseRepository;
            }

            public async Task<ExpenseToReturnDto> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
            {
                var expenseFromRepo = await _expenseRepository.RetrieveById(request.ExpenseId);
                return _mapper.Map<ExpenseToReturnDto>(expenseFromRepo);
            }
        }
    }
}
