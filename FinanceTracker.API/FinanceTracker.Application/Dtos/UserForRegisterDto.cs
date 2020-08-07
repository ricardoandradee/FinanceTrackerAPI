using System;

namespace FinanceTracker.Application.Dtos
{
    public class UserForRegisterDto
    {
        public UserForRegisterDto()
        {
            CreatedDate = DateTime.Now;
            LastActive = DateTime.Now;
        }

        public string UserName { get; set; }
        public string BaseCurrency { get; set; }
        public decimal Wallet { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActive { get; set; }

    }
}