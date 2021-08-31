using FinanceTracker.Infrastructure.Persistence.Data;
using System.Linq;
using FinanceTracker.Application.Common.Extensions;

namespace FinanceTracker.Infrastructure.Persistence
{
    public class ApplicationDbContextSeed
    {
        public static void SeedDataBase(ApplicationDbContext context)
        {
            if (!context.Currencies.Any())
            {
                var currencies = CurrencyData.GetCurrencyList();
                foreach (var currency in currencies)
                {
                    context.Currencies.Add(currency);
                }
                context.SaveChanges();
            }
            if (!context.StateTimeZones.Any())
            {
                var timeZones = TimeZoneData.GetTimeZoneList();
                var timeZonesSplited = timeZones.SplitList(100);
                foreach (var tzSplited in timeZonesSplited)
                {
                    foreach (var timeZone in tzSplited)
                    {
                        context.StateTimeZones.Add(timeZone);
                    }
                    context.SaveChanges();
                }
            }

            if (!context.Users.Any())
            {
                var users = UserData.GetUserList();
                foreach (var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("password", out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.Email = user.Email.ToLower().Trim();
                    user.FullName = user.FullName.ToLower();

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
