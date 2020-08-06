using FinanceTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UserExists(string userName);
        Task<List<string>> GetAllUserNames();
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
    }
}
