using Microsoft.EntityFrameworkCore;
using Products.api.Entities;

namespace Products.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}