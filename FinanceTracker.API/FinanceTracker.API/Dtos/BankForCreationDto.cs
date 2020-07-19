using System;
using System.Collections.Generic;

namespace FinanceTracker.API.Dtos
{
    public class BankForCreationDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Branch { get; set; }
        public bool IsActive { get; set; }
        public AccountForCreationDto AccountForCreation { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}