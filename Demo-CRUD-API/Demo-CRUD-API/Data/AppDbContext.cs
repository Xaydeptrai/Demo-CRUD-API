using Demo_CRUD_API.Data.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Demo_CRUD_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
