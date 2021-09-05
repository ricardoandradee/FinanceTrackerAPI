using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Users
{
    public class ResetUserPasswordCommand : IRequest<Response<string>>
    {
        public UserPasswordResetDto UserPasswordResetDto { get; }
        public ResetUserPasswordCommand(UserPasswordResetDto userPasswordResetDto)
        {
            UserPasswordResetDto = userPasswordResetDto;
        }

        public class LoginUserHandler : IRequestHandler<ResetUserPasswordCommand, Response<string>>
        {
            private readonly IUserRepository _userRepository;

            public LoginUserHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Response<string>> Handle(ResetUserPasswordCommand request, CancellationToken cancellationToken)
            {
                return await _userRepository.ResetUserPassword(request.UserPasswordResetDto);
            }
        }
    }
}
