using Microsoft.EntityFrameworkCore;
using TheBestCloth.DAL.Model;

namespace TheBestCloth.DAL.Data
{
    public class PostgresContext: DbContext
    {
        public PostgresContext(DbContextOptions opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingItem>();
        }

        public DbSet<ShoppingItem> ShoppingItems { get; set; }

    }
}
