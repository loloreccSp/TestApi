

using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands
{
    public class UpsertProductCommand
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }

        public DateTime ProductCreated { get; set; }


        public Product UpsertProduct()
        {
            var product = new Product
            {
                ProductId = ProductId,
                ProductName = ProductName,
                ProductDescription = ProductDescription,
                Price = Price,
                ProductCreated = ProductCreated,
            };
            return product;
        }
    }
    public class UpsertProductCommandHandler : IRequestHandler<UpsertProductCommand, ProductResponse>
    {
        private readonly TestApiMovieContext _context;

        public UpsertProductCommandHandler(TestApiMovieContext context) => _context = context;

        public async Task<ProductResponse> Handle(UpsertProductCommand request, CancellationToken cancellationToken = default)
        {
            var product = await GetProductAsync(request.ProductId, cancellationToken);
            if (product == null) 
            {
                product = request.UpsertProduct();
                await _context.Products.AddAsync(product, cancellationToken);
            }
            else
            {
                product.ProductId = request.ProductId;
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
