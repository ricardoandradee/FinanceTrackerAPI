using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Banks;
using FinanceTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Banks
{
    public class CreateBankWithAccountCommand : IRequest<BankToReturnDto>
    {
        public BankForCreationDto BankForCreationDto { get; }
        public CreateBankWithAccountCommand(BankForCreationDto bankForCreationDto)
        {
            BankForCreationDto = bankForCreationDto;
        }

        public class CreateBankWithAccountHandler : IRequestHandler<CreateBankWithAccountCommand, BankToReturnDto>
        {
            private readonly IBankRepository _bankRepository;
            private readonly IMapper _mapper;

            public CreateBankWithAccountHandler(IBankRepository bankRepository, IMapper mapper)
            {
                _mapper = mapper;
                _bankRepository = bankRepository;
            }

            public async Task<BankToReturnDto> Handle(CreateBankWithAccountCommand request, CancellationToken cancellationToken)
            {
                var bankToBeCreated = _mapper.Map<Bank>(request.BankForCreationDto);
                var bankCreated = await _bankRepository.CreateBankWithAccount(bankToBeCreated);

                return _mapper.Map<BankToReturnDto>(bankCreated);
            }
        }
    }
}
