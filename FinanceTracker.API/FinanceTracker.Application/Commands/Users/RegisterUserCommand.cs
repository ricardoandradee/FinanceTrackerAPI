using AutoMapper;
using FinanceTracker.Application.Common.Exceptions;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Users;
using FinanceTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Users
{
    public class RegisterUserCommand : IRequest<Response<UserForDetailedDto>>
    {
        public UserForRegisterDto UserForRegisterDto { get; }
        public RegisterUserCommand(UserForRegisterDto userForRegisterDto)
        {
            UserForRegisterDto = userForRegisterDto;
        }

        public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Response<UserForDetailedDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public RegisterUserHandler(IUserRepository userRepository, IMapper mapper)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<Response<UserForDetailedDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                request.UserForRegisterDto.UserName = request.UserForRegisterDto.UserName.ToLower();

                if (await _userRepository.UserExists(request.UserForRegisterDto.UserName))
                {
                    return Response.Fail<UserForDetailedDto>("User name is already registed in our database.");
                }

                var UserToCreate = _mapper.Map<User>(request.UserForRegisterDto);

                var createdUser = await _userRepository.Register(UserToCreate, request.UserForRegisterDto.Password);

                return Response.Success(_mapper.Map<UserForDetailedDto>(createdUser));
            }
        }
    }
}
