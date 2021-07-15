using AutoMapper;
using FinanceTracker.Application.Common.Exceptions;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Expenses;
using FinanceTracker.Application.Dtos.Accounts;
using FinanceTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
                var expenseFromRepo = await _unitOfWorkRepository.Context.Expenses
                                      .Include(e => e.Category)
                                      .Include(e => e.Currency)
                                      .FirstAsync(e => e.Id == request.ExpenseId);

                expenseFromRepo.Transaction = null;

                if (expenseFromRepo == null)
                {
                    throw new NotFoundException(nameof(Expense), request.ExpenseId);
                }

                _mapper.Map(request.ExpenseForUpdateDto, expenseFromRepo);
                
                var accountId = request.ExpenseForUpdateDto.AccountId.GetValueOrDefault(0);
                if (accountId > 0)
                {
                    expenseFromRepo.Transaction = await CreateTransaction(request, expenseFromRepo, accountId);
                }
                
                if (await _unitOfWorkRepository.SaveChanges() > 0)
                {
                    var expenseToReturn = _mapper.Map<ExpenseToReturnDto>(expenseFromRepo);                    
                    if (expenseFromRepo.Transaction != null)
                    {
                        expenseToReturn.Account = _mapper.Map<AccountToReturnDto>(expenseFromRepo.Transaction.Account);
                    }

                    return expenseToReturn;
                }

                return null;
            }

            private async Task<Transaction> CreateTransaction(UpdateExpenseCommand request, Expense expense, int accountId)
            {
                var transactionAmout = request.ExpenseForUpdateDto.TransactionAmount.GetValueOrDefault(0);
                var accountFromRepo = await _accountRepository.RetrieveById(accountId);
                accountFromRepo.CurrentBalance -= transactionAmout;

                return new Transaction
                {
                    AccountId = accountId,
                    BalanceAfterTransaction = accountFromRepo.CurrentBalance,
                    CreatedDate = System.DateTimeOffset.Now,
                    Action = "Debit",
                    Description = $"Payment at {expense.Establishment}",
                    Amount = transactionAmout
                };
            }
        }
    }
}
