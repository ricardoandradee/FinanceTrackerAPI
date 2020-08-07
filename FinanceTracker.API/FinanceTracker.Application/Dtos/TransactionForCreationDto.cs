using System;

namespace FinanceTracker.Application.Dtos
{
    public class TransactionForCreationDto
    {
        public TransactionForCreationDto()
        {
            CreatedDate = DateTime.Now;
        }

        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public int AccountId { get; set; }
        public string Action { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}