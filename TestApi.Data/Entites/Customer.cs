﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TestApiMovie.Data.Entites
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
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

        public ICollection<Order> CustomerOrder { get; set; }

        public virtual Cart CustomerCart { get; set; }
    }
}
