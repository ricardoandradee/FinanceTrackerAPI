using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Banks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Banks
{
    public class UpdateBankInfoCommand : IRequest<bool>
    {
        public int BankId { get; }
        public BankForUpdateDto BankForUpdateDto { get; }
        public UpdateBankInfoCommand(int bankId, BankForUpdateDto bankForUpdateDto)
        {
            BankId = bankId;
            BankForUpdateDto = bankForUpdateDto;
        }

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
}
