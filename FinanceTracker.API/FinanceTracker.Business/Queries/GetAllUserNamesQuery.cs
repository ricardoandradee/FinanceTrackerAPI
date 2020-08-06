using FinanceTracker.Business.Dtos;
using MediatR;
using System.Collections.Generic;

namespace FinanceTracker.Business.Queries
{
    public class GetAllUserNamesQuery : IRequest<List<string>>
    {
        public GetAllUserNamesQuery()
        {
        }
    }
}
