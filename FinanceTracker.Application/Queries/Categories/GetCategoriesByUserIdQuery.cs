using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Categories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Queries.Categories
{
    public class GetCategoriesByUserIdQuery : IRequest<List<CategoryToReturnDto>>
    {
        public int UserId { get; }
        public GetCategoriesByUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public class GetCategoriesByUserIdHandler : IRequestHandler<GetCategoriesByUserIdQuery, List<CategoryToReturnDto>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetCategoriesByUserIdHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _mapper = mapper;
                _categoryRepository = categoryRepository;
            }

            public async Task<List<CategoryToReturnDto>> Handle(GetCategoriesByUserIdQuery request, CancellationToken cancellationToken)
            {
                var categoriesFromRepo = await _categoryRepository.GetCategoriesByUserId(request.UserId);
                var categoriesToReturnDto = _mapper.Map<List<CategoryToReturnDto>>(categoriesFromRepo);

                foreach (var category in categoriesToReturnDto)
                {
                    if (!await _categoryRepository.ExistsAnyExpensesConnectedToCategory(category.Id))
                    {
                        category.CanBeDeleted = true;
                    }
                }

                return categoriesToReturnDto;
            }
        }
    }
}
