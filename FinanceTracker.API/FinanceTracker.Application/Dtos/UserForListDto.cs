using System;

namespace FinanceTracker.Application.Dtos
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string BaseCurrency { get; set; }
        public decimal Wallet { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}