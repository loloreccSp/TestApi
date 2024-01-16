using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;

namespace TestApiMovie.Service.Queries.QueriesById
{
    public class GetCustomersQueryById : IRequestHandler<int,CustomerResponse>
    {
        private readonly TestApiMovieContext _context;

        public GetCustomersQueryById(TestApiMovieContext context) => _context = context;

        public async Task<CustomerResponse> Handle(int id, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .AsNoTracking()
                .Where(x => x.CustomerId == id)
                .Select(x => new CustomerResponse
                {
                    CustomerId = x.CustomerId,
                    CustomerLogin = x.CustomerLogin,
                    CustomerName = x.CustomerName,
                    CustomerEmail = x.CustomerEmail,
                    CustomerPhone = x.CustomerPhone,
                    CustomerCreated = x.CustomerCreated,
                })
                .SingleOrDefaultAsync(cancellationToken);
        }

    }
}
