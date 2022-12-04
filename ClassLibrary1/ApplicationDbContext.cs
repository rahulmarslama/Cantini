using Cantini.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Cantini.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<FoodItem> FoodItem { get; set; }
        public DbSet<Student> Student { get; set; }
       
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        

    }
}