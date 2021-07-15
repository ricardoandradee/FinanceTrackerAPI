using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Expenses;
using FinanceTracker.Application.Dtos.Accounts;
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
            private readonly ITransactionRepository _transactionRepository;
            private readonly IAccountRepository _accountRepository;
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private readonly IMapper _mapper;

            public CreateExpenseHandler(IExpenseRepository expenseRepository,
                IMapper mapper, IUnitOfWorkRepository unitOfWorkRepository,
                IAccountRepository accountRepository,
                ITransactionRepository transactionRepository)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
                _expenseRepository = expenseRepository;
                _transactionRepository = transactionRepository;
                _accountRepository = accountRepository;
            }

            public async Task<ExpenseToReturnDto> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
            {
                var expense = _mapper.Map<Expense>(request.ExpenseForCreationDto);
                expense.Transaction = null;
                var accountId = request.ExpenseForCreationDto.AccountId.GetValueOrDefault(0);
                if (accountId > 0)
                {
                    expense.Transaction = await CreateTransaction(request, expense, accountId);
                }

                await _expenseRepository.Add(expense);

                if (await _unitOfWorkRepository.SaveChanges() > 0)
                {
                    expense.Category = await _unitOfWorkRepository.Context.Categories.FindAsync(expense.CategoryId);
                    expense.Currency = await _unitOfWorkRepository.Context.Currencies.FindAsync(expense.CurrencyId);
                    var expenseToReturn = _mapper.Map<ExpenseToReturnDto>(expense);
                    if (expense.Transaction != null)
                    {
                        expenseToReturn.Account = _mapper.Map<AccountToReturnDto>(expense.Transaction.Account);
                    }

                    return expenseToReturn;
                }

                return null;
            }

            private async Task<Transaction> CreateTransaction(CreateExpenseCommand request, Expense expense, int accountId)
            {
                var transactionAmout = request.ExpenseForCreationDto.TransactionAmount.GetValueOrDefault(0);
                var accountFromRepo = await _accountRepository.RetrieveById(accountId);
                accountFromRepo.CurrentBalance -= transactionAmout;

                return new Transaction
                {
                    AccountId = accountId,
                    BalanceAfterTransaction = accountFromRepo.CurrentBalance,
                    CreatedDate = expense.CreatedDate,
                    Action = "Debit",
                    Description = $"Payment at {expense.Establishment}.",
                    Amount = transactionAmout
                };
            }
        }
    }
}