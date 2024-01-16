

using System.ComponentModel.DataAnnotations;

namespace TestApiMovie.Contract.Request
{
    public class UpsertOrderRequest
    {
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int OrderAmout { get; set; }

    }
}
