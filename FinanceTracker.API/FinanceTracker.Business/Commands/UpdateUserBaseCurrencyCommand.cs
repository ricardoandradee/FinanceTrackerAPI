using FinanceTracker.Business.Dtos;
using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class UpdateUserBaseCurrencyCommand : IRequest<UserForDetailedDto>
    {
        public int UserId { get; }
        public string UserCurrency { get; }
        public UpdateUserBaseCurrencyCommand(int userId, string userCurrency)
        {
            UserId = userId;
            UserCurrency = userCurrency;
        }
    }
}
