using Microsoft.EntityFrameworkCore;
using SortingPaginationExample.Data.Entities;

namespace SortingPaginationExample.Data
{
    public class DataContext : DbContext 
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
