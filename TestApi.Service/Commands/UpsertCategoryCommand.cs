
using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands
{
    public class UpsertCategoryCommand
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public Category UpsertCategory()
        {
            var category = new Category
            {
                CategoryId = CategoryId,
                CategoryName = CategoryName,
                CategoryDescription = CategoryDescription
            };
            return category;
        }
    }

    public class UpsertCategoryCommandHandler : IRequestHandler<UpsertCategoryCommand, CategoryResponse>
    {
        private readonly TestApiMovieContext _context;
        
        public UpsertCategoryCommandHandler(TestApiMovieContext context) => _context = context;

        public async Task<CategoryResponse> Handle(UpsertCategoryCommand request, CancellationToken cancellationToken = default)
        {
            var category = await GetCategoryAsync(request.CategoryId, cancellationToken);
            if (category == null)
            {
                category = request.UpsertCategory();
                await _context.AddAsync(category, cancellationToken);
            }
            else
            {
                category.CategoryName = request.CategoryName;
                category.CategoryDescription = request.CategoryDescription;
            }

            //category.CategoryName = request.CategoryName;
            //category.CategoryDescription = request.CategoryDescription;

            await _context.SaveChangesAsync(cancellationToken);

            return new CategoryResponse
            {
                CategoryId = category.CategoryId,
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription
            };
        }

        private async Task<Category> GetCategoryAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Categorys.SingleOrDefaultAsync(c => c.CategoryId == id, cancellationToken);
        }
    }
}
