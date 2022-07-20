using blazor_metrozon.Models;
using Microsoft.EntityFrameworkCore;

namespace blazor_metrozon.Data
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) {}
        
        public DbSet<Product> Products { get; set; }
    }
}
