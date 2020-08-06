using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos;

namespace FinanceTracker.Application.Queries.Payments
{
    public class GetPaymentByIdQuery : IRequest<PaymentToReturnDto>
    {
        public int PaymentId { get; }

        public GetPaymentByIdQuery(int paymentId)
        {
            PaymentId = paymentId;
        }

        public class GetPaymentByIdHandler : IRequestHandler<GetPaymentByIdQuery, PaymentToReturnDto>
        {
            private readonly IPaymentRepository _paymentRepository;
            private readonly IMapper _mapper;

            public GetPaymentByIdHandler(IPaymentRepository paymentRepository, IMapper mapper)
            {
                _mapper = mapper;
                _paymentRepository = paymentRepository;
            }

            public async Task<PaymentToReturnDto> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
            {
                var paymentFromRepo = await _paymentRepository.RetrieveById(request.PaymentId);
                return _mapper.Map<PaymentToReturnDto>(paymentFromRepo);
            }
        }
    }
}
