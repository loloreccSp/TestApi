

using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands.Put
{
    public class PutCustomerCommand
    {
        public int CustomerIdPut { get; set; }

        public string CustomerLogin { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }

        public DateTime CustomerCreated { get; set; }

    }

    public class PutCustomerCommandHandler : IRequestHandler<PutCustomerCommand, CustomerResponse>
    {
        private readonly TestApiMovieContext _context;

        public PutCustomerCommandHandler(TestApiMovieContext context) => _context = context; 

        public async Task<CustomerResponse> Handle(PutCustomerCommand request, CancellationToken cancellationToken = default)
        {
            var customer = await GetCustmerAsync(request.CustomerIdPut, cancellationToken);

            if (customer != null)
            {
                customer.CustomerLogin = request.CustomerLogin;
                customer.CustomerName = request.CustomerName;
                customer.CustomerEmail = request.CustomerEmail;
                customer.CustomerPhone = request.CustomerPhone;
                customer.CustomerCreated = request.CustomerCreated;
            }
            await _context.SaveChangesAsync(cancellationToken);

            return new CustomerResponse
            {
                CustomerId = customer.CustomerId,
                CustomerLogin = request.CustomerLogin,
                CustomerName = request.CustomerName,
                CustomerEmail = request.CustomerEmail,
                CustomerPhone = request.CustomerPhone,
                CustomerCreated = request.CustomerCreated,
            };
        }

        public async Task<Customer> GetCustmerAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.CustomerId == id, cancellationToken);
        }
    }
}
