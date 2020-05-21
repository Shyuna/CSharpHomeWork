using System.Data.Entity;
using ConsoleApp3;

namespace ConsoleApp3
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("OrderDataBase")
        {
            Database.SetInitializer(
              new DropCreateDatabaseIfModelChanges<OrderContext>());
        }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}

