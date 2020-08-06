using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Commands
{
    public class DeleteBankInfoCommand : IRequest<bool>
    {
        public int BankId { get; }
        public DeleteBankInfoCommand(int bankId)
        {
            BankId = bankId;
        }

        public class DeleteBankInfoHandler : IRequestHandler<DeleteBankInfoCommand, bool>
        {
            private readonly IBankRepository _bankRepository;
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;

            public DeleteBankInfoHandler(IBankRepository bankRepository,
                IUnitOfWorkRepository unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _bankRepository = bankRepository;
            }

            public async Task<bool> Handle(DeleteBankInfoCommand request, CancellationToken cancellationToken)
            {
                var bankFromRepo = await _bankRepository.RetrieveById(request.BankId);
                _bankRepository.Delete(bankFromRepo);
                return await _unitOfWorkRepository.SaveChanges() > 0;
            }
        }
    }
}
