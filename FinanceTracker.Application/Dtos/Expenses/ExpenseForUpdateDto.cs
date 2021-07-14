using FinanceTracker.Application.Dtos.Transactions;

namespace FinanceTracker.Application.Dtos.Expenses
{
    public class ExpenseForUpdateDto
    {
        public int CategoryId { get; set; }
        public string Establishment { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public TransactionForCreationDto Transaction { get; set; }
    }
}
