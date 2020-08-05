using AutoMapper;
using FinanceTracker.Business.Commands;
using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Models;
using FinanceTracker.Business.Queries;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
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
