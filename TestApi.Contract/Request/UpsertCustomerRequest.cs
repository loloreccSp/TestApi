

using System.ComponentModel.DataAnnotations;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Contract.Request
{
    public class UpsertCustomerRequest
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerLogin { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(75)]
        public string CustomerEmail { get; set; }

        [Required]
        [StringLength(12)]
        public string CustomerPhone { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CustomerCreated { get; set; }

    }
}
