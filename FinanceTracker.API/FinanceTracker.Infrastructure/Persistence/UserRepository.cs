using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Persistence
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWorkRepository unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<List<User>> GetExistingUsersDetails()
        {
            return await _unitOfWork.Context.Users.Select(x => new User
            {
                UserName = x.UserName,
                Email = x.Email
            }).ToListAsync();
        }

        public async Task<bool> UserExists(string userName)
        {
            if (await _unitOfWork.Context.Users.AnyAsync(x => x.UserName == userName))
                return true;

            return false;
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _unitOfWork.Context.Users
                                .Include(u => u.StateTimeZone)
                                .Include(u => u.Currency)
                                .FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }

                return true;
            }
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passowrdHash, passowrdSalt;
            CreatePasswordHash(password, out passowrdHash, out passowrdSalt);

            user.PasswordHash = passowrdHash;
            user.PasswordSalt = passowrdSalt;

            await _unitOfWork.Context.Users.AddAsync(user);
            await _unitOfWork.SaveChanges();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passowrdHash, out byte[] passowrdSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passowrdSalt = hmac.Key;
                passowrdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
