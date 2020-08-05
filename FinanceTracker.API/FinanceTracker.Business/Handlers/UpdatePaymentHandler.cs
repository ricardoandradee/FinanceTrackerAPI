using AutoMapper;
using FinanceTracker.Business.Commands;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
    public class UpdatePaymentHandler : IRequestHandler<UpdatePaymentCommand, bool>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public UpdatePaymentHandler(IPaymentRepository paymentRepository,
            IMapper mapper, IUnitOfWorkRepository unitOfWorkRepository)
        {
            _mapper = mapper;
            _unitOfWorkRepository = unitOfWorkRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<bool> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentFromRepo = await _paymentRepository.RetrieveById(request.PaymentId);
            _mapper.Map(request.PaymentForUpdateDto, paymentFromRepo);

            return await _unitOfWorkRepository.SaveChanges() > 0;
        }
    }
}
