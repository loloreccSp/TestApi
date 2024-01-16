
using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;

namespace TestApiMovie.Service.Queries.QueriesById
{
    public class GetCartsQueryById : IRequestHandler<int, CartResponse>
    {
        private readonly TestApiMovieContext _context;

        public GetCartsQueryById(TestApiMovieContext context) => _context = context;

        public async Task<CartResponse> Handle(int cartId, CancellationToken cancellationToken = default)
        {
            return await _context.Carts
                .AsNoTracking()
                .Where(x => x.CartId == cartId)
                .Select(x => new CartResponse
                {
                    Id = x.CartId,
                    CartProduct = x.CartProduct
                })
                .SingleOrDefaultAsync(cancellationToken);

        }
    }
}
