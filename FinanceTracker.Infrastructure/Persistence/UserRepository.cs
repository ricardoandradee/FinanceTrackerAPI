using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Users;
using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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
                FullName = x.FullName,
                Email = x.Email
            }).ToListAsync();
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _unitOfWork.Context.Users.AnyAsync(x => x.Email == email.ToLower().Trim()))
                return true;

            return false;
        }

        public async Task<Response<User>> Login(string email, string password)
        {
            var user = await _unitOfWork.Context.Users
                                .Include(u => u.StateTimeZone)
                                .Include(u => u.Currency)
                                .FirstOrDefaultAsync(x => x.Email == email.ToLower().Trim());

            var successfullyLoggedIn = user != null ? VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt) : false;
            if (!successfullyLoggedIn)
            {
                return Response.Fail<User>("Incorrect E-mail or Password!");
            }

            if (!user.IsVerified)
            {
                return Response.Fail<User>("Your profile is not verified. " +
                    "Please, click on 'Verify Email Now' button to confirm your account, " +
                    "or use the 'Forgot password?' link.");
            }

            return Response.Success(user);
        }

        public async Task<Response<string>> ConfirmUserRegistration(UserValidationDto userValidation)
        {
            var user = await _unitOfWork.Context.Users.FindAsync(userValidation.UserId);
            if (user == null || !IsUserConfirmationCodeValid(userValidation, user))
                return Response.Fail<string>("It was not possible to validate your account! Please, contact the support!");

            user.ConfirmationCode = null;
            user.IsVerified = true;
            await _unitOfWork.SaveChanges();

            return Response.Success("Your account was successfully validated!");
        }

        private static bool IsUserConfirmationCodeValid(UserValidationDto userValidation, User user)
        {
            return user.ConfirmationCode == userValidation.ConfirmationCode && userValidation.ConfirmationCode != null;
        }

        public async Task<User> GetUserWithDependenciesById(int userId)
        {
            var user = await _unitOfWork.Context.Users
                                .Include(u => u.StateTimeZone)
                                .Include(u => u.Currency)
                                .FirstOrDefaultAsync(x => x.Id == userId);

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
            user.IsVerified = false;
            user.ConfirmationCode = Guid.NewGuid();

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
