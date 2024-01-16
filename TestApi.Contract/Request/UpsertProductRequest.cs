

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Contract.Request
{
    public class UpsertProductRequest
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(150)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductDescription { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ProductCreated { get; set; }

    }
}
