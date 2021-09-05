using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Users;
using FinanceTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UserExistsByEmail(string email);
        Task<List<User>> GetExistingUsersDetails();
        Task<User> GetUserWithDependenciesById(int userId);
        Task<User> Register(User user, string password);
        Task<Response<User>> Login(string email, string password);
        Task<Response<string>> ConfirmUserRegistration(UserValidationDto userValidation);
        Task<Response<User>> SetUserConfirmationCodeByEmail(string email);
        Task<Response<string>> ResetUserPassword(UserPasswordResetDto userPasswordResetDto);
    }
}
