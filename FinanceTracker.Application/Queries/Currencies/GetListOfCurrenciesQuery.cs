using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Currencies;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Currencies
{
    public class GetListOfCurrenciesQuery : IRequest<List<CurrencyToReturnDto>>
    {
        public GetListOfCurrenciesQuery()
        {
        }

        public class GetListOfCurrenciesHandler : IRequestHandler<GetListOfCurrenciesQuery, List<CurrencyToReturnDto>>
        {
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private readonly IMapper _mapper;

            public GetListOfCurrenciesHandler(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<List<CurrencyToReturnDto>> Handle(GetListOfCurrenciesQuery request, CancellationToken cancellationToken)
            {
                var currenciesFromRepo = await _unitOfWorkRepository.Context.Currencies.ToListAsync();
                return _mapper.Map<List<CurrencyToReturnDto>>(currenciesFromRepo);
            }
        }
    }
}
