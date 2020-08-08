using FinanceTracker.Application.Dtos.Accounts;
using System.Collections.Generic;

namespace FinanceTracker.Application.Dtos.Banks
{
    public class BankForUpdateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Branch { get; set; }
        public bool IsActive { get; set; }
        public ICollection<AccountForCreationDto> AccountsForCreation { get; set; }
    }
}