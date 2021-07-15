using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Accounts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Accounts
{
    public class GetAccountByIdQuery : IRequest<AccountToReturnDto>
    {
        public int AccountId { get; }
        public GetAccountByIdQuery(int accountId)
        {
            AccountId = accountId;
        }

        public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, AccountToReturnDto>
        {
            private readonly IUnitOfWorkRepository _unitOfWork;
            private readonly IMapper _mapper;

            public GetAccountByIdHandler(IUnitOfWorkRepository unitOfWork, IMapper mapper)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<AccountToReturnDto> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
            {

                var accountFromRepo = await _unitOfWork.Context.Accounts
                                .Include(a => a.Transactions)
                                .Include(a => a.Currency)
                                .FirstAsync(a => a.Id == request.AccountId);

                return _mapper.Map<AccountToReturnDto>(accountFromRepo);
            }
        }
    }
}
