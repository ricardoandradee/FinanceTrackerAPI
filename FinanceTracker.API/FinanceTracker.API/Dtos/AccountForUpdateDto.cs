namespace FinanceTracker.API.Dtos
{
    public class AccountForUpdateDto
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string AccountCurrency { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }        
    }
}