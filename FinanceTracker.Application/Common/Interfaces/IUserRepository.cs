using FinanceTracker.Application.Common.Models;
using FinanceTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UserExists(string userName);
        Task<List<User>> GetExistingUsersDetails();
        Task<User> GetUserWithDependenciesById(int userId);
        Task<User> Register(User user, string password);
        Task<Response<User>> Login(string userName, string password);
    }
}
