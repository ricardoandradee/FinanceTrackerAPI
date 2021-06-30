using FinanceTracker.Application.Dtos.Currencies;
using FinanceTracker.Application.Dtos.Transactions;
using System;
using System.Collections.Generic;

namespace FinanceTracker.Application.Dtos.Accounts
{
    public class AccountToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public CurrencyDto Currency { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
        public ICollection<TransactionToReturnWithoutAccountDto> Transactions { get; set; }
        public int BankId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}