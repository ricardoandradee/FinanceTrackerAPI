using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Users
{
    public class GetUserByIdQuery : IRequest<UserForDetailedDto>
    {
        public int UserId { get; }
        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }

        public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserForDetailedDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<UserForDetailedDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.RetrieveById(request.UserId);
                return _mapper.Map<UserForDetailedDto>(user);
            }
        }
    }
}
