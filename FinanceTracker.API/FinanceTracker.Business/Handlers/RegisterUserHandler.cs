using AutoMapper;
using FinanceTracker.Business.Commands;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Models;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserForDetailedDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserForDetailedDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            request.UserForRegisterDto.UserName = request.UserForRegisterDto.UserName.ToLower();

            if (await _userRepository.UserExists(request.UserForRegisterDto.UserName))
            {
                return null;
            }

            var UserToCreate = _mapper.Map<User>(request.UserForRegisterDto);

            var createdUser = await _userRepository.Register(UserToCreate, request.UserForRegisterDto.Password);

            return _mapper.Map<UserForDetailedDto>(createdUser);
        }
    }
}
