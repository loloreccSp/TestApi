using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;

namespace TestApiMovie.Service.Queries
{
    public class GetCustomersQuery : IRequestHandler<IList<CustomerResponse>>
    {
        private readonly TestApiMovieContext _context;

        public GetCustomersQuery(TestApiMovieContext context) => _context = context;

        public async Task<IList<CustomerResponse>> Handle(CancellationToken cancellationToken = default)
        {
            return await _context.Customers
                .AsNoTracking()
                .Select(x => new CustomerResponse
                {
                    CustomerId = x.CustomerId,
                    CustomerLogin = x.CustomerLogin,
                    CustomerName = x.CustomerName,
                    CustomerEmail = x.CustomerEmail,
                    CustomerPhone = x.CustomerPhone,
                    CustomerCreated = x.CustomerCreated,
                })
                .OrderByDescending(x => x.CustomerId)
                .ToListAsync(cancellationToken);
        }
    }
}
