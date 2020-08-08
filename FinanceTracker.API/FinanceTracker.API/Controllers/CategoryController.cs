using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Application.Commands.Categories;
using FinanceTracker.Application.Dtos.Categories;
using FinanceTracker.Application.Queries.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [UserAuthorization]
    [Route("api/user/{userId}/category")]
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("GetCategoryById/{categoryId}")]
        [TypeFilter(typeof(CategoryAuthorizationAttribute))]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var query = new GetCategoryByIdQuery(categoryId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("GetCategoriesByUserId")]
        public async Task<IActionResult> GetCategoriesByUserId(int userId)
        {
            var query = new GetCategoriesByUserIdQuery(userId);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpDelete]
        [Route("DeleteCategory/{categoryId}")]
        [TypeFilter(typeof(CategoryAuthorizationAttribute))]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var command = new DeleteCategoryCommand(categoryId);
            var result = await Mediator.Send(command);
            return result ? (IActionResult)NoContent() : BadRequest();
        }

        [HttpPut]
        [Route("UpdateCategory/{categoryId}")]
        [TypeFilter(typeof(CategoryAuthorizationAttribute))]
        public async Task<IActionResult> UpdateCategory(int categoryId, CategoryForUpdateDto categoryForUpdateDto)
        {
            var command = new UpdateCategoryCommand(categoryId, categoryForUpdateDto);
            var result = await Mediator.Send(command);
            return result ? (IActionResult)NoContent() : BadRequest();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(int userId, CategoryForCreationDto categoryForCreationDto)
        {
            categoryForCreationDto.UserId = userId;

            var command = new CreateCategoryCommand(categoryForCreationDto);
            var result = await Mediator.Send(command);

            if (result != null)
            {
                return CreatedAtAction(nameof(GetCategoryById),
                    new { categoryId = result.Id, categoryForCreationDto.UserId }, result);
            }

            throw new Exception("Creating category failed on save.");
        }
    }
}
