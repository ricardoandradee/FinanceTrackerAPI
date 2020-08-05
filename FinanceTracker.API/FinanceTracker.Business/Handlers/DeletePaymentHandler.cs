using AutoMapper;
using FinanceTracker.Business.Commands;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Queries;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
    public class DeletePaymentHandler : IRequestHandler<DeletePaymentCommand, bool>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public DeletePaymentHandler(IPaymentRepository paymentRepository, IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<bool> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentFromRepo = await _paymentRepository.RetrieveById(request.PaymentId);
            _paymentRepository.Delete(paymentFromRepo);

            return await _unitOfWorkRepository.SaveChanges() > 0;
        }
    }
}
