using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Users
{
    public class LoginUserCommand : IRequest<Response<UserForListDto>>
    {
        public UserForLoginDto UserForLoginDto { get; }
        public LoginUserCommand(UserForLoginDto userForLoginDto)
        {
            UserForLoginDto = userForLoginDto;
        }

        public class LoginUserHandler : IRequestHandler<LoginUserCommand, Response<UserForListDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public LoginUserHandler(IUserRepository userRepository, IMapper mapper)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<Response<UserForListDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var userFromRepo = await _userRepository.Login(request.UserForLoginDto.UserName.ToLower(), request.UserForLoginDto.Password);

                if (userFromRepo.Ok)
                {
                    return Response.Success(_mapper.Map<UserForListDto>(userFromRepo.Data));
                }

                return Response.Fail<UserForListDto>(userFromRepo.Message);
            }
        }
    }
}
