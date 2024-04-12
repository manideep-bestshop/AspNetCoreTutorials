using CRUDWithEFDbFirstWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithEFDbFirstWebApi.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
