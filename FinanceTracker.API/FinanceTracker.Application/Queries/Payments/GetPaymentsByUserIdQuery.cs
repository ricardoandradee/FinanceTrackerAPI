using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Payments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Payments
{
    public class GetPaymentsByUserIdQuery : IRequest<List<PaymentToReturnDto>>
    {
        public int UserId { get; }
        public GetPaymentsByUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public class GetPaymentsByUserIdHandler : IRequestHandler<GetPaymentsByUserIdQuery, List<PaymentToReturnDto>>
        {
            private readonly IPaymentRepository _paymentRepository;
            private readonly IMapper _mapper;

            public GetPaymentsByUserIdHandler(IPaymentRepository paymentRepository, IMapper mapper)
            {
                _mapper = mapper;
                _paymentRepository = paymentRepository;
            }

            public async Task<List<PaymentToReturnDto>> Handle(GetPaymentsByUserIdQuery request, CancellationToken cancellationToken)
            {
                var paymentsFromRepo = await _paymentRepository.GetPaymentsByUserId(request.UserId);
                return _mapper.Map<List<PaymentToReturnDto>>(paymentsFromRepo);
            }
        }
    }
}
