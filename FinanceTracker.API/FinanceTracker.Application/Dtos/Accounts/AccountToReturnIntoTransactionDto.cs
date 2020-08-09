using FinanceTracker.Application.Dtos.Currencies;

namespace FinanceTracker.Application.Dtos.Accounts
{
    public class AccountToReturnIntoTransactionDto
    {
        public int Id { get; set; }
        public CurrencyDto Currency { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
    }
}