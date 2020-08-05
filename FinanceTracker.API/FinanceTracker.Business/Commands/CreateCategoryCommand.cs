using FinanceTracker.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
