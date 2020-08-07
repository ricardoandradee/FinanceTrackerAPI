using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Users
{
    public class UpdateUserBaseCurrencyCommand : IRequest<UserForDetailedDto>
    {
        public int UserId { get; }
        public string BaseCurrency { get; }
        public UpdateUserBaseCurrencyCommand(int userId, string baseCurrency)
        {
            UserId = userId;
            BaseCurrency = baseCurrency;
        }

        public class UpdateUserBaseCurrencyHandler : IRequestHandler<UpdateUserBaseCurrencyCommand, UserForDetailedDto>
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

            public async Task<UserForDetailedDto> Handle(UpdateUserBaseCurrencyCommand request, CancellationToken cancellationToken)
            {
                var userFromRepo = await _userUepository.RetrieveById(request.UserId);

                if (userFromRepo.BaseCurrency != request.BaseCurrency)
                {
                    userFromRepo.BaseCurrency = request.BaseCurrency;
                    if (await _unitOfWorkRepository.SaveChanges() > 0)
                    {
                        return _mapper.Map<UserForDetailedDto>(userFromRepo);
                    }
                }
                return null;
            }
        }
    }
}
