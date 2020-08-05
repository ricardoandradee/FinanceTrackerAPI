using FinanceTracker.Business.Dtos;
using MediatR;
using System.Collections.Generic;

namespace FinanceTracker.Business.Queries
{
    public class GetUserByIdQuery : IRequest<UserForDetailedDto>
    {
        public int UserId { get; }
        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
