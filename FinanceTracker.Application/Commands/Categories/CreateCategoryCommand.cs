using AutoMapper;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Dtos.Categories;
using FinanceTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Categories
{
    public class CreateCategoryCommand : IRequest<CategoryToReturnDto>
    {
        public CategoryForCreationDto CategoryForCreationDto { get; }
        public CreateCategoryCommand(CategoryForCreationDto categoryForCreationDto)
        {
            CategoryForCreationDto = categoryForCreationDto;
        }

        public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryToReturnDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private readonly IMapper _mapper;

            public CreateCategoryHandler(ICategoryRepository categoryRepository,
                IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
                _categoryRepository = categoryRepository;
            }

            public async Task<CategoryToReturnDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<Category>(request.CategoryForCreationDto);
                await _categoryRepository.Add(category);

                if (await _unitOfWorkRepository.SaveChanges() > 0)
                {
                    var categoryToReturn = _mapper.Map<CategoryToReturnDto>(category);
                    categoryToReturn.CanBeDeleted = true;
                    return categoryToReturn;
                }

                return null;
            }
        }
    }
}
