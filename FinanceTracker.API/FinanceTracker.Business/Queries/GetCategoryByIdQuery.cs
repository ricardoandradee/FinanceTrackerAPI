using AutoMapper;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Queries
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
                if (!await _categoryRepository.ExistsAnyPaymentsConnectedToCategory(categoryToReturnDto.Id))
                {
                    categoryToReturnDto.CanBeDeleted = true;
                }

                return categoryToReturnDto;
            }
        }
    }
}
