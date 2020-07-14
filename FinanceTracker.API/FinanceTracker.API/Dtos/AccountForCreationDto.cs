using System;

namespace FinanceTracker.API.Dtos
{
    public class AccountForCreationDto
    {
        public int BankId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}