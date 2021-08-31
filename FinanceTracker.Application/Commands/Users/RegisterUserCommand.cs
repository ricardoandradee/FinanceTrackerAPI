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
    public class RegisterUserCommand : IRequest<Response<UserForDetailDto>>
    {
        public UserForRegisterDto UserForRegisterDto { get; }
        public RegisterUserCommand(UserForRegisterDto userForRegisterDto)
        {
            UserForRegisterDto = userForRegisterDto;
        }

        public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Response<UserForDetailDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public RegisterUserHandler(IUserRepository userRepository, IMapper mapper)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<Response<UserForDetailDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                request.UserForRegisterDto.Email = request.UserForRegisterDto.Email.ToLower();

                if (await _userRepository.UserExists(request.UserForRegisterDto.Email))
                {
                    return Response.Fail<UserForDetailDto>("Email is already registed in our database.");
                }

                var UserToCreate = _mapper.Map<User>(request.UserForRegisterDto);

                var createdUser = await _userRepository.Register(UserToCreate, request.UserForRegisterDto.Password);

                return Response.Success(_mapper.Map<UserForDetailDto>(createdUser));
            }
        }
    }
}
