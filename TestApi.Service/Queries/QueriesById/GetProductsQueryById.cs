

using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;

namespace TestApiMovie.Service.Queries.QueriesById
{
    public class GetProductsQueryById : IRequestHandler<int, ProductResponse>
    {
        private readonly TestApiMovieContext _context;

        public GetProductsQueryById(TestApiMovieContext context) => _context = context;

        public async Task<ProductResponse> Handle(int id, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(x => x.ProductId == id)
                .Select(x => new ProductResponse
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductDescription = x.ProductDescription,
                    Price = x.Price,
                    ProductCreated = x.ProductCreated,
                })
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
