using System;

namespace FinanceTracker.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public string Action { get; set; }
        public int ExpenseId { get; set; }
        public virtual Expense Expense { get; set; }
        public virtual Account Account { get; set; }
        public int AccountId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}