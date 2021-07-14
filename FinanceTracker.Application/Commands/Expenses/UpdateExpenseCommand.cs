using AutoMapper;
using FinanceTracker.Application.Common.Exceptions;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Expenses;
using FinanceTracker.Application.Dtos.Accounts;
using FinanceTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Expenses
{
    public class UpdateExpenseCommand : IRequest<ExpenseToReturnDto>
    {
        public int ExpenseId { get; }
        public ExpenseForUpdateDto ExpenseForUpdateDto { get; }
        public UpdateExpenseCommand(int expenseId, ExpenseForUpdateDto expenseForUpdateDto)
        {
            ExpenseForUpdateDto = expenseForUpdateDto;
            ExpenseId = expenseId;
        }

        public class UpdateExpenseHandler : IRequestHandler<UpdateExpenseCommand, ExpenseToReturnDto>
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

            public async Task<ExpenseToReturnDto> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
            {
                var expenseFromRepo = await _expenseRepository.RetrieveById(request.ExpenseId);
                expenseFromRepo.Transaction = null;

                if (expenseFromRepo == null)
                {
                    throw new NotFoundException(nameof(Expense), request.ExpenseId);
                }

                _mapper.Map(request.ExpenseForUpdateDto, expenseFromRepo);
                
                var accountId = request.ExpenseForUpdateDto.AccountId.GetValueOrDefault(0);
                if (accountId > 0)
                {
                    var transactionAmout = request.ExpenseForUpdateDto.TransactionAmount.GetValueOrDefault(0);
                    var accountFromRepo = await _accountRepository.RetrieveById(accountId);
                    accountFromRepo.CurrentBalance -= transactionAmout;
                    
                    expenseFromRepo.Transaction = new Transaction
                    {
                        AccountId = accountId,
                        BalanceAfterTransaction = accountFromRepo.CurrentBalance,
                        CreatedDate = System.DateTimeOffset.Now,
                        Action = "Debit",
                        Description = $"Payment at {expenseFromRepo.Establishment}",
                        Amount = transactionAmout
                    };
                }
                
                if (await _unitOfWorkRepository.SaveChanges() > 0)
                {
                    expenseFromRepo.Category = await _unitOfWorkRepository.Context.Categories.FindAsync(expenseFromRepo.CategoryId);
                    expenseFromRepo.Currency = await _unitOfWorkRepository.Context.Currencies.FindAsync(expenseFromRepo.CurrencyId);
                    var expenseToReturn = _mapper.Map<ExpenseToReturnDto>(expenseFromRepo);
                    
                    if (expenseFromRepo.Transaction != null)
                    {
                        expenseToReturn.Account = _mapper.Map<AccountToReturnDto>(expenseFromRepo.Transaction.Account);
                    }

                    return _mapper.Map<ExpenseToReturnDto>(expenseFromRepo);
                }

                return null;
            }
        }
    }
}
