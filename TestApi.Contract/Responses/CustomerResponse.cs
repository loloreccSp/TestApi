
namespace TestApiMovie.Contract.Responses
{
    public class CustomerResponse
    {
        public int CustomerId { get; set; }

        public string CustomerLogin { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }

        public DateTime CustomerCreated { get; set; }
    }
}
