using FinanceTracker.Application.Dtos.Accounts;
using System;
using System.Collections.Generic;

namespace FinanceTracker.Application.Dtos.Banks
{
    public class BankToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public bool IsActive { get; set; }
        public ICollection<AccountToReturnDto> Accounts { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}