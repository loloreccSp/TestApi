using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;

namespace TestApiMovie.Service.Queries
{
    public class GetCategoryQuery : IRequestHandler<IList<CategoryResponse>>
    {
        private readonly TestApiMovieContext _context;

        public GetCategoryQuery(TestApiMovieContext context) => _context = context;

        public async Task<IList<CategoryResponse>> Handle(CancellationToken cancellationToken = default)
        {
            return await _context.Categorys
                .AsNoTracking()
                .Select(x => new CategoryResponse
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    CategoryDescription = x.CategoryDescription
                })
                .OrderByDescending(x => x.CategoryId)
                .ToListAsync(cancellationToken);
        }
    }
}
