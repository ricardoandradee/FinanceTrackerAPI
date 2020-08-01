using AutoMapper;
using FinanceTracker.API.AuthorizationAttribute;
using FinanceTracker.API.Dtos;
using FinanceTracker.API.Models;
using FinanceTracker.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [UserAuthorization]
    [Route("api/user/{userId}/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository,
                                  IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetCategory/{categoryId}")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var categoryFromRepo = await _categoryRepository.RetrieveById(categoryId);

            if (categoryFromRepo == null)
            {
                return NotFound();
            }

            var categoryToReturnDto = _mapper.Map<CategoryToReturnDto>(categoryFromRepo);
            categoryToReturnDto.CanBeDeleted = !(await _categoryRepository.ExistsAnyPaymentsConnectedToCategory(categoryToReturnDto.Id));

            return Ok(categoryToReturnDto);
        }

        [HttpDelete]
        [Route("DeleteCategory/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int userId, int categoryId)
        {
            if (await _categoryRepository.ExistsAnyPaymentsConnectedToCategory(categoryId))
            {
                return BadRequest("This category has payments linked to it, therefore, it cannot be removed.");
            }

            if (await _categoryRepository.BelongsToUser(userId, categoryId) == false)
            {
                return BadRequest("This category does not belong to the logged in user.");
            }

            var categoryFromRepo = await _categoryRepository.RetrieveById(categoryId);
            _categoryRepository.Delete(categoryFromRepo);

            if (await _unitOfWorkRepository.SaveChanges() > 0)
            {
                return NoContent();
            }

            throw new Exception("Error deleting the category.");
        }

        [HttpPut]
        [Route("UpdateCategory/{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int userId, int categoryId, CategoryForUpdateDto categoryForUpdateDto)
        {
            if (await _categoryRepository.BelongsToUser(userId, categoryId) == false)
            {
                return BadRequest("This category does not belong to the logged in user.");
            }

            var categoryFromRepo = await _categoryRepository.RetrieveById(categoryId);
            _mapper.Map(categoryForUpdateDto, categoryFromRepo);

            if (await _unitOfWorkRepository.SaveChanges() > 0)
            {
                return NoContent();
            }

            throw new Exception("Error updating the category.");
        }

        [HttpGet]
        [Route("GetCategoriesForUser")]
        public async Task<IActionResult> GetCategoriesForUser(int userId)
        {
            var categoriesFromRepo = await _categoryRepository.GetCategoriesForUser(userId);

            var categoriesToReturnDto = _mapper.Map<IEnumerable<CategoryToReturnDto>>(categoriesFromRepo);

            foreach (var item in categoriesToReturnDto)
            {
                item.CanBeDeleted = !(await _categoryRepository.ExistsAnyPaymentsConnectedToCategory(item.Id));
            }
            
            return Ok(categoriesToReturnDto);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CategoryForCreationDto categoryForCreationDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            categoryForCreationDto.UserId = userId;

            var category = _mapper.Map<Category>(categoryForCreationDto);
            await _categoryRepository.Add(category);

            if (await _unitOfWorkRepository.SaveChanges() > 0)
            {
                var categoryToReturn = _mapper.Map<CategoryToReturnDto>(category);
                categoryToReturn.CanBeDeleted = true;

                return CreatedAtAction(nameof(GetCategory),
                    new { categoryId = category.Id, userId = userId }, categoryToReturn);
            }

            throw new Exception("Creating category failed on save.");
        }
    }
}
