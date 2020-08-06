using FinanceTracker.Business.Dtos;
using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class RegisterUserCommand : IRequest<UserForDetailedDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; }
        public RegisterUserCommand(UserForRegisterDto userForRegisterDto)
        {
            UserForRegisterDto = userForRegisterDto;
        }
    }
}
