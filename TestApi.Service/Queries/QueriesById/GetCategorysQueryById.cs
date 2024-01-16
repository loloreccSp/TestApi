
using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;

namespace TestApiMovie.Service.Queries.QueriesById
{
    public class GetCategorysQueryById : IRequestHandler<int, CategoryResponse>
    {
        private readonly TestApiMovieContext _context;

        public GetCategorysQueryById(TestApiMovieContext context) => _context = context;

        public async Task<CategoryResponse> Handle(int cartId, CancellationToken cancellationToken = default)
        {
            return await _context.Categorys
                .AsNoTracking()
                .Where(x => x.CategoryId == cartId)
                .Select(x => new CategoryResponse
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    CategoryDescription = x.CategoryDescription
                })
                .SingleOrDefaultAsync(cancellationToken);

        }
    }
}
