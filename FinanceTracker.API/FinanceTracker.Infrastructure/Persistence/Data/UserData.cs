﻿using FinanceTracker.Domain.Entities;
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
                    UserName = "Lauren",
                    DateOfBirth = DateTime.Parse("1990-03-04"),
                    CreatedDate = DateTime.Parse("2020-06-08"),
                    LastActive = DateTime.Parse("2020-06-08"),
                    BaseCurrency = "EUR",
                    StateTimeZoneId = 48,
                    Country = "Viet Nam"
                    },
                new User {
                    UserName = "Cameron",
                    DateOfBirth = DateTime.Parse("1994-08-03"),
                    CreatedDate = DateTime.Parse("2020-01-06"),
                    LastActive = DateTime.Parse("2020-01-06"),
                    BaseCurrency = "AUD",
                    StateTimeZoneId = 47,
                    Country = "French Polynesia"
                    },
                new User {
                    UserName = "Joshwa",
                    DateOfBirth = DateTime.Parse("1986-03-16"),
                    CreatedDate = DateTime.Parse("2020-07-02"),
                    LastActive = DateTime.Parse("2017-08-09"),
                    BaseCurrency = "CAD",
                    StateTimeZoneId = 27,
                    Country = "Pakistan"
                    }
            };
            return users;
        }
    }
}