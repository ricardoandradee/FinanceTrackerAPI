using System;
using System.Collections.Generic;

namespace FinanceTracker.API.Dtos
{
    public class BankToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Branch { get; set; }
        public bool IsActive { get; set; }
        public ICollection<AccountToReturnDto> Accounts { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}