
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TestApiMovie.Data.Entites
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public virtual Product CartProduct { get; set; }
    }
}
