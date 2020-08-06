using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Commands
{
    public class DeletePaymentCommand : IRequest<bool>
    {
        public int PaymentId { get; }
        public DeletePaymentCommand(int paymentId)
        {
            PaymentId = paymentId;
        }

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
}
