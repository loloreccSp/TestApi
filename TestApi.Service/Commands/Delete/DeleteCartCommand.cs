

using Microsoft.EntityFrameworkCore;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands.Delete
{
    public class DeleteCartCommand
    {
        public int CartId { get; set; }
        
    }

    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, bool>
    {
        private readonly TestApiMovieContext _context;

        public DeleteCartCommandHandler(TestApiMovieContext context) => _context = context;


        public async Task<bool> Handle(DeleteCartCommand request, CancellationToken cancellationToken = default)
        {
            var cart = await GetCartAsync(request.CartId, cancellationToken);

            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }

            return false;

        }

        private async Task<Cart> GetCartAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Carts.SingleOrDefaultAsync(c => c.CartId == id, cancellationToken);
        }
    }
}
