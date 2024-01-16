using Microsoft.EntityFrameworkCore;

using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;

namespace TestApiMovie.Service.Queries
{
    public class GetProductsQuery : IRequestHandler<IList<ProductResponse>>
    {
        private readonly TestApiMovieContext _context;

        public GetProductsQuery(TestApiMovieContext context) => _context = context;

        public async Task<IList<ProductResponse>> Handle(CancellationToken cancellationToken = default)
        {
            return await _context.Products
                .AsNoTracking()
                .Select(x => new ProductResponse
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductDescription = x.ProductDescription,
                    Price = x.Price,
                    ProductCreated = x.ProductCreated,
                })
                .OrderByDescending(x => x.ProductId)
                .ToListAsync(cancellationToken);
        }
    }
}
