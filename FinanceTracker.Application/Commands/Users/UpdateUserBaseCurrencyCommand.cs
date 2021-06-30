using AutoMapper;
using FinanceTracker.Application.Common.Exceptions;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Users;
using FinanceTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Users
{
    public class UpdateUserBaseCurrencyCommand : IRequest<UserForDetailDto>
    {
        public int UserId { get; }
        public int CurrencyId { get; }
        public UpdateUserBaseCurrencyCommand(int userId, int currencyId)
        {
            UserId = userId;
            CurrencyId = currencyId;
        }

        public class UpdateUserBaseCurrencyHandler : IRequestHandler<UpdateUserBaseCurrencyCommand, UserForDetailDto>
        {
            private readonly IUserRepository _userUepository;
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private readonly IMapper _mapper;

            public UpdateUserBaseCurrencyHandler(IUserRepository userUepository,
                IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
            {
                _mapper = mapper;
                _userUepository = userUepository;
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<UserForDetailDto> Handle(UpdateUserBaseCurrencyCommand request, CancellationToken cancellationToken)
            {
                var userFromRepo = await _userUepository.RetrieveById(request.UserId);

                if (userFromRepo == null)
                {
                    throw new NotFoundException(nameof(User), request.UserId);
                }

                if (userFromRepo.CurrencyId != request.CurrencyId)
                {
                    userFromRepo.CurrencyId = request.CurrencyId;
                    if (await _unitOfWorkRepository.SaveChanges() > 0)
                    {
                        return _mapper.Map<UserForDetailDto>(userFromRepo);
                    }
                }
                return null;
            }
        }
    }
}
