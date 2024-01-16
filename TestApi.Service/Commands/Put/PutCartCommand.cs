
using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands.Put
{
    public class PutCartCommand
    {
        public int CartId { get; set; }

        public virtual Product CartProduct { get; set; }
    }

    public class PutCartCommandHandler : IRequestHandler<PutCartCommand, CartResponse>
    {
        private readonly TestApiMovieContext _context;

        public PutCartCommandHandler(TestApiMovieContext context) => _context = context;


        public async Task<CartResponse> Handle(PutCartCommand request, CancellationToken cancellationToken = default)
        {
            var cart = await GetCartAsync(request.CartId, cancellationToken);

            if (cart != null)
            {
                cart.CartId = request.CartId;
                cart.CartProduct = request.CartProduct;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new CartResponse
            {
                Id = cart.CartId,
                CartProduct = request.CartProduct,
            };
        }

        private async Task<Cart> GetCartAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Carts.SingleOrDefaultAsync(c => c.CartId == id, cancellationToken);
        }
    }
}

