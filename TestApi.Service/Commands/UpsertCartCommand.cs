

using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands
{
    public class UpsertCartCommand
    {
        public int Id { get; set; }
        public virtual Product CartProduct { get; set; }

        public Cart UpsertCart()
        {
            var cart = new Cart
            {
            CartId = Id,
            CartProduct = CartProduct,
            };
            return cart;
        }       
    }

    public class UpsertCartCommandHandler : IRequestHandler<UpsertCartCommand, CartResponse>
    {
        private readonly TestApiMovieContext _context;

        public UpsertCartCommandHandler(TestApiMovieContext context) => _context = context;


        public async Task<CartResponse> Handle(UpsertCartCommand request, CancellationToken cancellationToken = default)
        {
            var cart = await GetCartAsync(request.Id, cancellationToken);
            if (cart == null)
            {
                cart = request.UpsertCart();
                await _context.AddAsync(cart, cancellationToken);
            }
            else
            {
                cart.CartId = request.Id;
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
