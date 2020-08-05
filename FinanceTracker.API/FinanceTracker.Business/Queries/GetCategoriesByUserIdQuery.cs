using FinanceTracker.Business.Dtos;
using MediatR;
using System.Collections.Generic;

namespace FinanceTracker.Business.Queries
{
    public class GetCategoriesByUserIdQuery : IRequest<List<CategoryToReturnDto>>
    {
        public int UserId { get; }
        public GetCategoriesByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
