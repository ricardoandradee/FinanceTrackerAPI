using AutoMapper;
using FinanceTracker.Business.Commands;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Models;
using FinanceTracker.Business.Queries;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
    public class UpdateBankInfoHandler : IRequestHandler<UpdateBankInfoCommand, bool>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public UpdateBankInfoHandler(IBankRepository bankRepository,
            IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWorkRepository = unitOfWorkRepository;
            _bankRepository = bankRepository;
        }

        public async Task<bool> Handle(UpdateBankInfoCommand request, CancellationToken cancellationToken)
        {
            var bankFromRepo = await _bankRepository.RetrieveById(request.BankId);
            _mapper.Map(request.BankForUpdateDto, bankFromRepo);
            return await _unitOfWorkRepository.SaveChanges() > 0;
        }
    }
}
