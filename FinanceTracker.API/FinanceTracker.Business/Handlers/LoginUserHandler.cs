using AutoMapper;
using FinanceTracker.Business.Commands;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, UserForListDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserForListDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userFromRepo = await _userRepository.Login(request.UserForLoginDto.UserName.ToLower(), request.UserForLoginDto.Password);

            if (userFromRepo != null)
            {
                return _mapper.Map<UserForListDto>(userFromRepo);
            }

            return null;
        }
    }
}
