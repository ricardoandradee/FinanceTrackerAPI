using FinanceTracker.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Business.Commands
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int CategoryId { get; }
        public DeleteCategoryCommand(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
