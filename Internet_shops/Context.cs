using Internet_Shop;
using System.Data.Entity;

namespace Internet_shops
{
    public class Context : DbContext
    {
        public Context() : base("DbConnectionString")
        {

        }

        public DbSet<CardClient> CardClient { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ShopCart> ShopCart { get; set; }
    }
}
