using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.UserLoginHistories;
using FinanceTracker.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Expenses.UserLoginHistories
{
    public class CreateUserLoginHistoryCommand : IRequest<int>
    {
        public UserLoginHistoryForCreationDto UserLoginHistoryForCreationDto { get; }
        public CreateUserLoginHistoryCommand(UserLoginHistoryForCreationDto userLoginHistoryForCreationDto)
        {
            UserLoginHistoryForCreationDto = userLoginHistoryForCreationDto;
        }

        public class CreateUserLoginHistoryHandler : IRequestHandler<CreateUserLoginHistoryCommand, int>
        {
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private readonly IUserResolverService _userResolverService;
            private readonly IMapper _mapper;

            public CreateUserLoginHistoryHandler(IUserResolverService userResolverService, IMapper mapper, IUnitOfWorkRepository unitOfWorkRepository)
            {
                _mapper = mapper;
                _userResolverService = userResolverService;
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<int> Handle(CreateUserLoginHistoryCommand request, CancellationToken cancellationToken)
            {
                var location = _userResolverService.GetUsersLocation().Result;

                var userLoginHistory = _mapper.Map<UserLoginHistory>(request.UserLoginHistoryForCreationDto);
                userLoginHistory.ActionDateTime = DateTimeOffset.UtcNow;
                userLoginHistory.GeoLocation = location.ToString();
                userLoginHistory.IPAddress = location.Ip;

                await _unitOfWorkRepository.Context.UserLoginHistories.AddAsync(userLoginHistory);

                return await _unitOfWorkRepository.SaveChanges();
            }
        }
    }
}
