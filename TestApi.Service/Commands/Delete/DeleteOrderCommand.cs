

using Microsoft.EntityFrameworkCore;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands.Delete
{
    public class DeleteOrderCommand
    {
        public int OrderIdDel { get; set; }

    }
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly TestApiMovieContext _context;

        public DeleteOrderCommandHandler(TestApiMovieContext context) => _context = context;


        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken = default)
        {
            var order = await GetOrderAsync(request.OrderIdDel, cancellationToken);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<Order> GetOrderAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Orders.SingleOrDefaultAsync(o => o.OrderId == id, cancellationToken);
        }
    }


}
