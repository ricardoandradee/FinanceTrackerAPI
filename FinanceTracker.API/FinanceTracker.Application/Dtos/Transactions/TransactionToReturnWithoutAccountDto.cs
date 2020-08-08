using System;

namespace FinanceTracker.Application.Dtos.Transactions
{
    public class TransactionToReturnWithoutAccountDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Action { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}