using FinanceTracker.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Business.Commands
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int CategoryId { get; }
        public CategoryForUpdateDto CategoryForUpdateDto { get; set; }
        public UpdateCategoryCommand(int categoryId, CategoryForUpdateDto categoryForUpdateDto)
        {
            CategoryForUpdateDto = categoryForUpdateDto;
            CategoryId = categoryId;
        }
    }
}
