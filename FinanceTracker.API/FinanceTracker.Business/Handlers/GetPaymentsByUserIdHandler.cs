using AutoMapper;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Queries;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
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
