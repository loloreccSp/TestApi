using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;

namespace TestApiMovie.Service.Queries
{
    public class GetCartsQuery : IRequestHandler<IList<CartResponse>>
    {
        private readonly TestApiMovieContext _context;

        public GetCartsQuery(TestApiMovieContext context) => _context = context;

        public async Task<IList<CartResponse>> Handle(CancellationToken cancellationToken = default)
        {
            return await _context.Carts
                .AsNoTracking()
                .Select(x => new CartResponse
                {
                    Id = x.CartId,
                    CartProduct = x.CartProduct,
                })
                .OrderByDescending(x => x.Id)
                .ToListAsync(cancellationToken);
        }
    }
}
