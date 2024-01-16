
using TestApiMovie.Data.Entites;

namespace TestApiMovie.Contract.Responses
{
    public class CartResponse
    {
        public int Id { get; set; }
        public virtual Product CartProduct { get; set; }
    }
}
