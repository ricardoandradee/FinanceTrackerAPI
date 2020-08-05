using FinanceTracker.Business.Dtos;
using MediatR;

namespace FinanceTracker.Business.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryToReturnDto>
    {
        public CategoryForCreationDto CategoryForCreationDto { get; }
        public CreateCategoryCommand(CategoryForCreationDto categoryForCreationDto)
        {
            CategoryForCreationDto = categoryForCreationDto;
        }
    }
}
