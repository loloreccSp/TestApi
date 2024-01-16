
using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;

namespace TestApiMovie.Service.Queries
{
    public class GetOrdersQuery : IRequestHandler<IList<OrderResponse>>
    {
        private readonly TestApiMovieContext _context;

        public GetOrdersQuery(TestApiMovieContext context) => _context = context;

        public async Task<IList<OrderResponse>> Handle(CancellationToken cancellationToken = default)
        {
            return await _context.Orders
                .AsNoTracking()
                .Select(x => new OrderResponse
                {
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,
                    CustomerId = x.CustomerId,
                    OrderAmout = x.OrderAmout,
                    OrderTotal = x.OrderTotal,
                })
                .OrderByDescending(x => x.OrderId)
                .ToListAsync(cancellationToken);
        }
    }
}
