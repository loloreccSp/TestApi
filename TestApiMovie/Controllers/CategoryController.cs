using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TestApiMovie.Contract.Request;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;
using TestApiMovie.Service;
using TestApiMovie.Service.Commands;
using TestApiMovie.Service.Commands.Delete;
using TestApiMovie.Service.Commands.Put;

namespace TestApiMovie.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetCategoryAsync([FromServices]IRequestHandler<IList<CategoryResponse>> getCategory)
        {
            return Ok(await getCategory.Handle());
        }

        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int CategoryId, IRequestHandler<int,CategoryResponse> getCategoryById)
        {
            return Ok(await getCategoryById.Handle(CategoryId));
        }

        [HttpPost]
        public async Task<IActionResult> UpsertCategory([FromServices]IRequestHandler<UpsertCategoryCommand,CategoryResponse> upsertCategory, [FromBody]UpsertCategoryRequest request)
        {
            var category = await upsertCategory.Handle(new UpsertCategoryCommand
            {
                CategoryId = request.CategoryId,
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription,
            });

            return Ok(category);
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategoryById(int categoryId, [FromServices] IRequestHandler<DeleteCategoryCommand, bool> deleteCategoryById)
        {
            var delete = await deleteCategoryById.Handle(new DeleteCategoryCommand { CategoryIdDel = categoryId });

            if (delete)
            {
                return Ok(delete);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> PutCategoryById([FromServices] IRequestHandler<PutCategoryCommand, CategoryResponse> putCategoryById, [FromBody] UpsertCategoryRequest request)
        {
            var category = await putCategoryById.Handle(new PutCategoryCommand
            {
                CategoryIdPut = request.CategoryId,
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription,
            });

            return Ok(category);
        }
    }
}
