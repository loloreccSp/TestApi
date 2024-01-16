

using Microsoft.EntityFrameworkCore;
using TestApiMovie.Data.Context;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Service.Commands.Delete
{
    public class DeleteCustomerCommand
    {
        public int CustomerIdDel { get; set; }

    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly TestApiMovieContext _context;

        public DeleteCustomerCommandHandler(TestApiMovieContext context) => _context = context; 

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken = default)
        {
            var customer = await GetCustmerAsync(request.CustomerIdDel, cancellationToken);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;

        }

        public async Task<Customer> GetCustmerAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.CustomerId == id, cancellationToken);
        }
    }
}
