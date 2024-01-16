

using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands.Put
{
    public class PutProductCommand
    {
        public int ProductIdPut { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }

        public DateTime ProductCreated { get; set; }


    }
    public class PutProductCommandHandler : IRequestHandler<PutProductCommand, ProductResponse>
    {
        private readonly TestApiMovieContext _context;

        public PutProductCommandHandler(TestApiMovieContext context) => _context = context;

        public async Task<ProductResponse> Handle(PutProductCommand request, CancellationToken cancellationToken = default)
        {
            var product = await GetProductAsync(request.ProductIdPut, cancellationToken);

            if (product != null) 
            {
                product.ProductName = request.ProductName;
                product.ProductDescription = request.ProductDescription;
                product.Price = request.Price;
                product.ProductCreated = request.ProductCreated;
            }
            await _context.SaveChangesAsync(cancellationToken);

            return new ProductResponse
            {
                ProductId = product.ProductId,
                ProductName = request.ProductName,
                ProductDescription = request.ProductDescription,
                Price = request.Price,
                ProductCreated = request.ProductCreated,
            };
        }

        public async Task<Product> GetProductAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.ProductId == id, cancellationToken);
        }
    }
}
