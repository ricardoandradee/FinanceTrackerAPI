using System;
using System.Collections.Generic;

namespace FinanceTracker.Application.Dtos
{
    public class AccountToReturnIntoTransactionDto
    {
        public int Id { get; set; }
        public string AccountCurrency { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
    }
}