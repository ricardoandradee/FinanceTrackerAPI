using FinanceTracker.Business.Dtos;
using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class LoginUserCommand : IRequest<UserForListDto>
    {
        public UserForLoginDto UserForLoginDto { get; }
        public LoginUserCommand(UserForLoginDto userForLoginDto)
        {
            UserForLoginDto = userForLoginDto;
        }
    }
}
