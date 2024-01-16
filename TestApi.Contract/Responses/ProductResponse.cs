
namespace TestApiMovie.Contract.Responses
{
    public class ProductResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }

        public DateTime ProductCreated { get; set; }
    }
}
