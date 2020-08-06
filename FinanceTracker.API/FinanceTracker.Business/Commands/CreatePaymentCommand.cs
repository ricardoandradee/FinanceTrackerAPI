using AutoMapper;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Models;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Commands
{
    public class CreatePaymentCommand : IRequest<PaymentToReturnDto>
    {
        public PaymentForCreationDto PaymentForCreationDto { get; }
        public CreatePaymentCommand(PaymentForCreationDto paymentForCreationDto)
        {
            PaymentForCreationDto = paymentForCreationDto;
        }

        public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, PaymentToReturnDto>
        {
            private readonly IPaymentRepository _paymentRepository;
            private readonly ICategoryRepository _categoryRepository;
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private readonly IMapper _mapper;

            public CreatePaymentHandler(IPaymentRepository paymentRepository,
                ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWorkRepository unitOfWorkRepository)
            {
                _mapper = mapper;
                _categoryRepository = categoryRepository;
                _unitOfWorkRepository = unitOfWorkRepository;
                _paymentRepository = paymentRepository;
            }

            public async Task<PaymentToReturnDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
            {
                var payment = _mapper.Map<Payment>(request.PaymentForCreationDto);
                await _paymentRepository.Add(payment);

                if (await _unitOfWorkRepository.SaveChanges() > 0)
                {
                    payment.Category = await _categoryRepository.RetrieveById(payment.CategoryId);
                    return _mapper.Map<PaymentToReturnDto>(payment);
                }

                return null;
            }
        }
    }
}
