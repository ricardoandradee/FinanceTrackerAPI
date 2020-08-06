using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Payments
{
    public class UpdatePaymentCommand : IRequest<bool>
    {
        public int PaymentId { get; }
        public PaymentForUpdateDto PaymentForUpdateDto { get; }
        public UpdatePaymentCommand(int paymentId, PaymentForUpdateDto paymentForUpdateDto)
        {
            PaymentForUpdateDto = paymentForUpdateDto;
            PaymentId = paymentId;
        }

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
}
