

using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands
{
    public class UpsertOrderCommand
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int OrderAmout { get; set; }

        public decimal OrderTotal { get; set; }

        public Order UpsertOrder()
        {
            var order = new Order
            {
                OrderId = OrderId,
                ProductId = ProductId,
                CustomerId = CustomerId,
                OrderAmout = OrderAmout,
                OrderTotal = OrderTotal,
            };
            return order;
        }
    }
    public class UpsertOrderCommandHandler : IRequestHandler<UpsertOrderCommand, OrderResponse>
    {
        private readonly TestApiMovieContext _context;

        public UpsertOrderCommandHandler(TestApiMovieContext context) => _context = context;


        public async Task<OrderResponse> Handle(UpsertOrderCommand request, CancellationToken cancellationToken = default)
        {
            var order = await GetOrderAsync(request.OrderId, cancellationToken);

            if (order == null)
            {
                order = request.UpsertOrder();
                await _context.Orders.AddAsync(order, cancellationToken);
            }
            else
            {
                //order.OrderId = request.OrderId;
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
