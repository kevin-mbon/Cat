using CatWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace CatWeb.Data
{
    public class CatDbContext : DbContext
    {
        public CatDbContext(DbContextOptions<CatDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Cat> Cat { get; set; }
    }
}
