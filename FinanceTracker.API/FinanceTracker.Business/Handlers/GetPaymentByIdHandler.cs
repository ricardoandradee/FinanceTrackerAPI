﻿using AutoMapper;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Queries;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
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