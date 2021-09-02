using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Users
{
    public class LoginUserCommand : IRequest<Response<UserForDetailDto>>
    {
        public UserForLoginDto UserForLoginDto { get; }
        public LoginUserCommand(UserForLoginDto userForLoginDto)
        {
            UserForLoginDto = userForLoginDto;
        }

        public class LoginUserHandler : IRequestHandler<LoginUserCommand, Response<UserForDetailDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public LoginUserHandler(IUserRepository userRepository, IMapper mapper)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<Response<UserForDetailDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var userFromRepo = await _userRepository.Login(request.UserForLoginDto.Email.ToLower(), request.UserForLoginDto.Password);

                if (userFromRepo.Ok)
                {
                    if (!userFromRepo.Data.IsVerified)
                    {
                        return Response.Fail<UserForDetailDto>("Your profile is not verified. " +
                            "Please, click on 'Verify Email Now' button to confirm your account, " +
                            "or use the 'Forgot password?' link.");
                    }
                    return Response.Success(_mapper.Map<UserForDetailDto>(userFromRepo.Data));
                }

                return Response.Fail<UserForDetailDto>(userFromRepo.Message);
            }
        }
    }
}
