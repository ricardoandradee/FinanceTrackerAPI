using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FinanceTracker.Infrastructure.Persistence.Data
{
    public static class UserData
    {
        public static List<User> GetUserList()
        {
            var users = new List<User>()
            {
                new User {
                    FullName = "Lauren Smith",
                    Email = "lauren@gmail.com",
                    CreatedDate = DateTime.Parse("2020-06-08"),
                    CurrencyId = 12,
                    StateTimeZoneId = 48
                    },
                new User {
                    FullName = "Cameron Campbell",
                    Email = "cameron@gmail.com",
                    CreatedDate = DateTime.Parse("2020-01-06"),
                    CurrencyId = 12,
                    StateTimeZoneId = 47
                    },
                new User {
                    FullName = "Joshwa Lasterin",
                    Email = "joshwa@gmail.com",
                    CreatedDate = DateTime.Parse("2020-07-02"),
                    CurrencyId = 12,
                    StateTimeZoneId = 27
                    }
            };
            return users;
        }
    }
}
