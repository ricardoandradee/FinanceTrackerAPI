using System;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.API.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string UserName { get; set; }
        [MaxLength(3)]
        public string UserCurrency { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Wallet { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
    }
}
