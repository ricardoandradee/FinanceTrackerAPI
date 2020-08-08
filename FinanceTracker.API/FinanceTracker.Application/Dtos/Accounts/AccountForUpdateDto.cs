
namespace FinanceTracker.Application.Dtos.Accounts
{
    public class AccountForUpdateDto
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; }        
    }
}