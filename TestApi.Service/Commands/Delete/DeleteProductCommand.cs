

using Microsoft.EntityFrameworkCore;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands.Delete
{
    public class DeleteProductCommand
    {
        public int ProductIdDel { get; set; }

    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly TestApiMovieContext _context;

        public DeleteProductCommandHandler(TestApiMovieContext context) => _context = context;

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken = default)
        {
            var product = await GetProductAsync(request.ProductIdDel, cancellationToken);

            if (product != null) 
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<Product> GetProductAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.ProductId == id, cancellationToken);
        }
    }
}
