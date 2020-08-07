using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IUserVerification
    {
        Task<bool> BelongsToUser(int userId, int entityId);
    }
}
