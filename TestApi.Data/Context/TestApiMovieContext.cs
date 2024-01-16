using Microsoft.EntityFrameworkCore;
using TestApiMovie.Data.Entites;


namespace TestApiMovie.Data.Context
{
    public class TestApiMovieContext : DbContext
    {
        public TestApiMovieContext(DbContextOptions<TestApiMovieContext> options) : base(options) { }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

    }
}
