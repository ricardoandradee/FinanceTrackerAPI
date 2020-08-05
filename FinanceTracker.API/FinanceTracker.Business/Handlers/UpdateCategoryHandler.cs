using AutoMapper;
using FinanceTracker.Business.Commands;
using FinanceTracker.Business.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository,
            IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWorkRepository = unitOfWorkRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryFromRepo = await _categoryRepository.RetrieveById(request.CategoryId);
            _mapper.Map(request.CategoryForUpdateDto, categoryFromRepo);

            return await _unitOfWorkRepository.SaveChanges() > 0;
        }
    }
}
