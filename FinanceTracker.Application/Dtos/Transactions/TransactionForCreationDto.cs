using System;

namespace FinanceTracker.Application.Dtos.Transactions
{
    public class TransactionForCreationDto
    {
        public TransactionForCreationDto()
        {
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public int AccountId { get; set; }
        public string Action { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}