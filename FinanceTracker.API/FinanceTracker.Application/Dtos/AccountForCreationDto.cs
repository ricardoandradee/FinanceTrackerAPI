using System;

namespace FinanceTracker.Application.Dtos
{
    public class AccountForCreationDto
    {
        public AccountForCreationDto()
        {
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public string Name { get; set; }
        public string Number { get; set; }
        public string Currency { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
        public int BankId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}