using System;
using FinanceTracker.Application.Dtos.Accounts;
using FinanceTracker.Application.Dtos.Transactions;
using FinanceTracker.Application.Dtos.Categories;
using FinanceTracker.Application.Dtos.Currencies;

namespace FinanceTracker.Application.Dtos.Expenses
{
    public class ExpenseToReturnDto
    {
        public int Id { get; set; }
        public CategoryToReturnDto Category { get; set; }
        public string Establishment { get; set; }
        public bool IsPaid { get; set; }
        public CurrencyDto Currency { get; set; }
        public AccountToReturnDto Account { get; set; }
        public TransactionToReturnDto Transaction { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedDateString { get; set; }
    }
}
