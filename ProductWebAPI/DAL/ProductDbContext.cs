using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Models;

namespace ProductWebAPI.DAL
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions options):base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
