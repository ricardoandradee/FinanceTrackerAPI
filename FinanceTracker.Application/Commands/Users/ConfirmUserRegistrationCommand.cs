using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Users
{
    public class ConfirmUserRegistrationCommand : IRequest<Response<string>>
    {
        public UserValidationDto UserValidationDto { get; }
        public ConfirmUserRegistrationCommand(UserValidationDto userValidationDto)
        {
            UserValidationDto = userValidationDto;
        }

        public class LoginUserHandler : IRequestHandler<ConfirmUserRegistrationCommand, Response<string>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public LoginUserHandler(IUserRepository userRepository, IMapper mapper)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<Response<string>> Handle(ConfirmUserRegistrationCommand request, CancellationToken cancellationToken)
            {
                return await _userRepository.ConfirmUserRegistration(request.UserValidationDto);
            }
        }
    }
}
