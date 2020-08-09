using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.TimeZones;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Users
{
    public class GetListOfStateTimeZoneQuery : IRequest<List<StateTimeZoneToReturnDto>>
    {
        public GetListOfStateTimeZoneQuery()
        {
        }

        public class GetListOfStateTimeZoneHandler : IRequestHandler<GetListOfStateTimeZoneQuery, List<StateTimeZoneToReturnDto>>
        {
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private readonly IMapper _mapper;

            public GetListOfStateTimeZoneHandler(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<List<StateTimeZoneToReturnDto>> Handle(GetListOfStateTimeZoneQuery request, CancellationToken cancellationToken)
            {
                var timeZones = await _unitOfWorkRepository.Context.StateTimeZones.ToListAsync();
                return _mapper.Map<List<StateTimeZoneToReturnDto>>(timeZones);
            }
        }
    }
}
