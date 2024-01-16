using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TestApiMovie.Data.Entites
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        //[Required]
        //public virtual Cart OrberCustomerCart { get; set; }

        [Required]
        public int OrderAmout { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal OrderTotal { get; set; }
    }
}
