namespace FinanceTracker.Business.Dtos
{
    public class AccountForUpdateDto
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string AccountCurrency { get; set; }
        public bool IsActive { get; set; }        
    }
}