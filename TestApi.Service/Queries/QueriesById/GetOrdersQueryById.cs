
using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;

namespace TestApiMovie.Service.Queries.QueriesById
{
    public class GetOrdersQueryById : IRequestHandler<int, OrderResponse>
    {
        private readonly TestApiMovieContext _context;

        public GetOrdersQueryById(TestApiMovieContext context) => _context = context;

        public async Task<OrderResponse> Handle(int id, CancellationToken cancellationToken)
        {
            return await _context.Orders
                .AsNoTracking()
                .Where(x => x.OrderId == id)
                .Select(x => new OrderResponse
                {
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,
                    CustomerId = x.CustomerId,
                    OrderAmout = x.OrderAmout,
                    OrderTotal = x.OrderTotal
                })
                .SingleOrDefaultAsync(cancellationToken);

        }
    }
}
