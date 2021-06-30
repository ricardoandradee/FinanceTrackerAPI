using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Users;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Users
{
    public class GetExistingUsersDetailsQuery : IRequest<List<UserInfoForSignupDto>>
    {
        public GetExistingUsersDetailsQuery()
        {
        }

        public class GetExistingUsersDetailsHandler : IRequestHandler<GetExistingUsersDetailsQuery, List<UserInfoForSignupDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetExistingUsersDetailsHandler(IUserRepository userRepository, IMapper mapper)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<List<UserInfoForSignupDto>> Handle(GetExistingUsersDetailsQuery request, CancellationToken cancellationToken)
            {
                var users = await _userRepository.GetExistingUsersDetails();
                return _mapper.Map<List<UserInfoForSignupDto>>(users);
            }
        }
    }
}
