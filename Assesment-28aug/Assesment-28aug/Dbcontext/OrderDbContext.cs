using Assesment_28aug.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment_28aug.Dbcontext
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext() { }
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
