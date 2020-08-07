using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceTracker.Infrastructure.Persistence
{
    public class ApplicationDbContextSeed
    {
        public static void SeedUsers(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Users.Any())
            {
                var users = new List<User>()
                {
                    new User {
                        UserName = "Lauren",
                        DateOfBirth = DateTime.Parse("1990-03-04"),
                        CreatedDate = DateTime.Parse("2020-06-08"),
                        LastActive = DateTime.Parse("2020-06-08"),
                        BaseCurrency = "EUR",
                        TimeZone = "+10:00",
                        Country = "Viet Nam"
                     },
                    new User {
                        UserName = "Cameron",
                        DateOfBirth = DateTime.Parse("1994-08-03"),
                        CreatedDate = DateTime.Parse("2020-01-06"),
                        LastActive = DateTime.Parse("2020-01-06"),
                        BaseCurrency = "AUD",
                        TimeZone = "+09:30",
                        Country = "French Polynesia"
                     },
                    new User {
                        UserName = "Joshwa",
                        DateOfBirth = DateTime.Parse("1986-03-16"),
                        CreatedDate = DateTime.Parse("2020-07-02"),
                        LastActive = DateTime.Parse("2017-08-09"),
                        BaseCurrency = "CAD",
                        TimeZone = "+11:00",
                        Country = "Pakistan"
                     }
                };
                
                foreach (var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("password", out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.UserName = user.UserName.ToLower();

                    context.Users.Add(user);
                }

                context.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passowrdHash, out byte[] passowrdSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passowrdSalt = hmac.Key;
                passowrdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
