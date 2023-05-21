using Microsoft.EntityFrameworkCore;

namespace HimlayanEverestInsurance.Models
{
    public class AppDbContext:DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }


        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Customer>().HasIndex(c => c.Customer_Id).IsUnique();  
        }

    }
}
