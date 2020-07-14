using AutoMapper;
using FinanceTracker.API.Dtos;
using FinanceTracker.API.Models;
using FinanceTracker.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user/{userId}/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("GetCategory/{categoryId}")]
        public async Task<IActionResult> GetCategory(int userId, int categoryId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var categoryFromRepo = await _categoryRepository.RetrieveById(categoryId);

            if (categoryFromRepo == null)
            {
                return NotFound();
            }

            var categoryToReturnDto = _mapper.Map<CategoryToReturnDto>(categoryFromRepo);
            categoryToReturnDto.CanBeDeleted = !(await _categoryRepository.ExistsAnyPaymentsConnectedToCategory(categoryToReturnDto.Id));

            return Ok(categoryToReturnDto);
        }

        [HttpGet]
        [Route("GetCategoriesForUser")]
        public async Task<IActionResult> GetCategoriesForUser(int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

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

            if (await _categoryRepository.Add(category))
            {
                var categoryToReturn = _mapper.Map<CategoryToReturnDto>(category);
                categoryToReturn.CanBeDeleted = true;

                return CreatedAtAction(nameof(GetCategory),
                    new { categoryId = category.Id, userId = userId }, categoryToReturn);
            }

            throw new Exception("Creating category failed on save.");
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            if (await _categoryRepository.ExistsAnyPaymentsConnectedToCategory(id))
            {
                return BadRequest("This category has payments linked to it, therefore, it cannot be removed.");
            }

            if (await _categoryRepository.BelongsToUser(userId, id) == false)
            {
                return BadRequest("This category does not belong to the logged in user.");
            }

            var categoryFromRepo = await _categoryRepository.RetrieveById(id);

            if (await _categoryRepository.Delete(categoryFromRepo))
            {
                return NoContent();
            }

            throw new Exception("Error deleting the category.");
        }

        [HttpPut]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(int userId, int id, CategoryForUpdateDto categoryForUpdateDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            if (await _categoryRepository.BelongsToUser(userId, id) == false)
            {
                return BadRequest("This category does not belong to the logged in user.");
            }

            var categoryFromRepo = await _categoryRepository.RetrieveById(id);
            _mapper.Map(categoryForUpdateDto, categoryFromRepo);

            if (await _categoryRepository.Update(categoryFromRepo))
            {
                return NoContent();
            }

            throw new Exception("Error updating the category.");
        }
    }
}
