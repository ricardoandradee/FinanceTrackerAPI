namespace FinanceTracker.Application.Dtos.UserLoginHistories
{
    public class UserLoginHistoryForCreationDto
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
