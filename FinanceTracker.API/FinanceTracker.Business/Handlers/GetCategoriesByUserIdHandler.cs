using AutoMapper;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Queries;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
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
                if (!await _categoryRepository.ExistsAnyPaymentsConnectedToCategory(category.Id))
                {
                    category.CanBeDeleted = true;
                }
            }

            return categoriesToReturnDto;
        }
    }
}
