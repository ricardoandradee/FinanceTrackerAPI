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

            if (userFromRepo.UserCurrency != request.UserCurrency)
            {
                userFromRepo.UserCurrency = request.UserCurrency;
                if (await _unitOfWorkRepository.SaveChanges() > 0)
                {
                    return _mapper.Map<UserForDetailedDto>(userFromRepo);
                }
            }
            return null;
        }
    }
}
