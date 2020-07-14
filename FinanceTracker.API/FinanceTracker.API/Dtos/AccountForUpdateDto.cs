namespace FinanceTracker.API.Dtos
{
    public class AccountForUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public decimal CurrentBalance { get; set; }        
    }
}