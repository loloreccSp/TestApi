

using Microsoft.EntityFrameworkCore;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands
{
    public class UpsertCustomerCommand
    {
        public int CustomerId { get; set; }

        public string CustomerLogin { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }

        public DateTime CustomerCreated { get; set; }

        public Customer UpsertCuntomer()
        {
            var customer = new Customer
            {
                CustomerId = CustomerId,
                CustomerLogin = CustomerLogin,
                CustomerName = CustomerName,
                CustomerEmail = CustomerEmail,
                CustomerPhone = CustomerPhone,  
                CustomerCreated = CustomerCreated,
            };
            return customer;
        }
    }

    public class UpsertCustomerCommandHandler : IRequestHandler<UpsertCustomerCommand, CustomerResponse>
    {
        private readonly TestApiMovieContext _context;

        public UpsertCustomerCommandHandler(TestApiMovieContext context) => _context = context; 

        public async Task<CustomerResponse> Handle(UpsertCustomerCommand request, CancellationToken cancellationToken = default)
        {
            var customer = await GetCustmerAsync(request.CustomerId, cancellationToken);
            if (customer == null)
            {
                customer = request.UpsertCuntomer();
                await _context.Customers.AddAsync(customer, cancellationToken);
            }
            else
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
