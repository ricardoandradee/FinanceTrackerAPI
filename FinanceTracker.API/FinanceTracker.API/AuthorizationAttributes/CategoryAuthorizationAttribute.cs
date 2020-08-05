using FinanceTracker.Business.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace FinanceTracker.API.AuthorizationAttributes
{
    public sealed class CategoryAuthorizationAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryAuthorizationAttribute(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var isUserAuthorized = false;

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = context.RouteData.Values["userId"].ToString(); 
                var categoryId = context.RouteData.Values["categoryId"].ToString();

                if (int.TryParse(userId, out int userIdParsed)
                    && int.TryParse(categoryId, out int categoryIdParsed))
                {
                    isUserAuthorized = await _categoryRepository.BelongsToUser(userIdParsed, categoryIdParsed);
                }
            }
            
            if (!isUserAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
