using System;

namespace FinanceTracker.API.Dtos
{
    public class AccountForCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public string AccountCurrency { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
        public int BankId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}