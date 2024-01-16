

using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands.Put
{
    public class PutOrderCommand
    {
        public int OrderIdPut { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int OrderAmout { get; set; }

        public decimal OrderTotal { get; set; }

    }
    public class PutOrderCommandHandler : IRequestHandler<PutOrderCommand, OrderResponse>
    {
        private readonly TestApiMovieContext _context;

        public PutOrderCommandHandler(TestApiMovieContext context) => _context = context;


        public async Task<OrderResponse> Handle(PutOrderCommand request, CancellationToken cancellationToken = default)
        {
            var order = await GetOrderAsync(request.OrderIdPut, cancellationToken);

            if (order != null)
            {
                order.ProductId = request.ProductId;
                order.CustomerId = request.CustomerId;
                order.OrderAmout = request.OrderAmout;
                order.OrderTotal = request.OrderTotal;
            }
            await _context.SaveChangesAsync(cancellationToken);

            return new OrderResponse
            {
                OrderId = order.OrderId,
                ProductId = request.ProductId,
                CustomerId = request.CustomerId,
                OrderAmout = request.OrderAmout,
                OrderTotal = order.OrderTotal,
            };
        }

        public async Task<Order> GetOrderAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Orders.SingleOrDefaultAsync(o => o.OrderId == id, cancellationToken);
        }
    }


}
