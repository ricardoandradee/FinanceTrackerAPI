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
