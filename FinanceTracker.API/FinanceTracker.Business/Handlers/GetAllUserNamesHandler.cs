using AutoMapper;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Queries;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace FinanceTracker.Business.Handlers
{
    public class GetAllUserNamesHandler : IRequestHandler<GetAllUserNamesQuery, List<string>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserNamesHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<string>> Handle(GetAllUserNamesQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUserNames();
        }
    }
}
