using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FinanceTracker.Application.Common.Interfaces;

namespace FinanceTracker.Application.Commands.Categories
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int CategoryId { get; }
        public DeleteCategoryCommand(int categoryId)
        {
            CategoryId = categoryId;
        }

        public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;

            public DeleteCategoryHandler(ICategoryRepository categoryRepository,
                IUnitOfWorkRepository unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _categoryRepository = categoryRepository;
            }

            public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                if (await _categoryRepository.ExistsAnyPaymentsConnectedToCategory(request.CategoryId))
                {
                    return false;
                }

                var categoryFromRepo = await _categoryRepository.RetrieveById(request.CategoryId);
                _categoryRepository.Delete(categoryFromRepo);
                return await _unitOfWorkRepository.SaveChanges() > 0;
            }
        }
    }
}
