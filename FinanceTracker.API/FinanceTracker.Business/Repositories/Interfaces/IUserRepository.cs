using FinanceTracker.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UserExists(string userName);
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
    }
}
