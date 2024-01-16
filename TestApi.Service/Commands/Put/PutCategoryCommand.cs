
using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands.Put
{
    public class PutCategoryCommand
    {
        public int CategoryIdPut { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }

    public class PutCategoryCommandHandler : IRequestHandler<PutCategoryCommand, CategoryResponse>
    {
        private readonly TestApiMovieContext _context;
        
        public PutCategoryCommandHandler(TestApiMovieContext context) => _context = context;

        public async Task<CategoryResponse> Handle(PutCategoryCommand request, CancellationToken cancellationToken = default)
        {
            var category = await GetCategoryAsync(request.CategoryIdPut, cancellationToken);

            if (category != null) //category.CategoryId == request.CategoryIdPut
            {
                category.CategoryName = request.CategoryName;
                category.CategoryDescription = request.CategoryDescription;
            }
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
