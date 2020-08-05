using FinanceTracker.Business.Dtos;
using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int CategoryId { get; }
        public CategoryForUpdateDto CategoryForUpdateDto { get; }
        public UpdateCategoryCommand(int categoryId, CategoryForUpdateDto categoryForUpdateDto)
        {
            CategoryForUpdateDto = categoryForUpdateDto;
            CategoryId = categoryId;
        }
    }
}
