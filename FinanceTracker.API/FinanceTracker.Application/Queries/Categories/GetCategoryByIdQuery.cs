using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Categories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Categories
{
    public class GetCategoryByIdQuery : IRequest<CategoryToReturnDto>
    {
        public int CategoryId { get; }
        public GetCategoryByIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }

        public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryToReturnDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetCategoryByIdHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _mapper = mapper;
                _categoryRepository = categoryRepository;
            }

            public async Task<CategoryToReturnDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var categoryFromRepo = await _categoryRepository.RetrieveById(request.CategoryId);

                var categoryToReturnDto = _mapper.Map<CategoryToReturnDto>(categoryFromRepo);
                if (!await _categoryRepository.ExistsAnyExpensesConnectedToCategory(categoryToReturnDto.Id))
                {
                    categoryToReturnDto.CanBeDeleted = true;
                }

                return categoryToReturnDto;
            }
        }
    }
}
