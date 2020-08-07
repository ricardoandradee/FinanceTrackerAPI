using System;
using System.Collections.Generic;

namespace FinanceTracker.Application.Dtos
{
    public class BankForCreationDto
    {
        public BankForCreationDto()
        {
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public bool IsActive { get; set; }
        public ICollection<AccountForCreationDto> Accounts { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}