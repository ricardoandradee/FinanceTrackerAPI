using FinanceTracker.Business.Dtos;
using MediatR;

namespace FinanceTracker.Business.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryToReturnDto>
    {
        public int CategoryId { get; }
        public GetCategoryByIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
