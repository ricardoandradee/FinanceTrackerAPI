using System;

namespace FinanceTracker.API.Dtos
{
    public class TransactionToReturnDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Action { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public int AccountId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}