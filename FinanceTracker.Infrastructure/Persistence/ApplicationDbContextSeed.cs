using FinanceTracker.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using FinanceTracker.Application.Common.Extensions;

namespace FinanceTracker.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDataBaseAsync(ApplicationDbContext context)
        {
            if (!await context.Currencies.AnyAsync())
            {
                var currencies = CurrencyData.GetCurrencyList();
                context.Currencies.AddRange(currencies);
                await context.SaveChangesAsync();
            }

            if (!await context.StateTimeZones.AnyAsync())
            {
                var timeZones = TimeZoneData.GetTimeZoneList();
                var timeZonesSplited = timeZones.SplitList(100);
                foreach (var tzSplited in timeZonesSplited)
                {
                    context.StateTimeZones.AddRange(tzSplited);
                    await context.SaveChangesAsync();
                }
            }

            if (!await context.Users.AnyAsync())
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
                await context.SaveChangesAsync();
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
