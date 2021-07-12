using System;

namespace FinanceTracker.Application.Dtos.Expenses
{
    public class ExpenseForUpdateDto
    {
        public int CategoryId { get; set; }
        public string Establishment { get; set; }
        public int CurrencyId { get; set; }
        public decimal Price { get; set; }
    }
}
