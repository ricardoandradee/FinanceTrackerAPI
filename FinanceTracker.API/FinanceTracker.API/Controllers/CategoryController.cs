using FinanceTracker.API.AuthorizationAttributes;
using FinanceTracker.Application.Commands.Categories;
using FinanceTracker.Application.Dtos;
using FinanceTracker.Application.Queries.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [UserAuthorization]
    [Route("api/user/{userId}/category")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetCategoryById/{categoryId}")]
        [TypeFilter(typeof(CategoryAuthorizationAttribute))]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var query = new GetCategoryByIdQuery(categoryId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("GetCategoriesByUserId")]
        public async Task<IActionResult> GetCategoriesByUserId(int userId)
        {
            var query = new GetCategoriesByUserIdQuery(userId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpDelete]
        [Route("DeleteCategory/{categoryId}")]
        [TypeFilter(typeof(CategoryAuthorizationAttribute))]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var command = new DeleteCategoryCommand(categoryId);
            var result = await _mediator.Send(command);
            return result ? (IActionResult)NoContent() : BadRequest();
        }

        [HttpPut]
        [Route("UpdateCategory/{categoryId}")]
        [TypeFilter(typeof(CategoryAuthorizationAttribute))]
        public async Task<IActionResult> UpdateCategory(int categoryId, CategoryForUpdateDto categoryForUpdateDto)
        {
            var command = new UpdateCategoryCommand(categoryId, categoryForUpdateDto);
            var result = await _mediator.Send(command);
            return result ? (IActionResult)NoContent() : BadRequest();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CategoryForCreationDto categoryForCreationDto)
        {
            categoryForCreationDto.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var command = new CreateCategoryCommand(categoryForCreationDto);
            var result = await _mediator.Send(command);

            if (result != null)
            {
                return CreatedAtAction(nameof(GetCategoryById),
                    new { categoryId = result.Id, categoryForCreationDto.UserId }, result);
            }

            throw new Exception("Creating category failed on save.");
        }
    }
}
