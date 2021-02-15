using Microsoft.EntityFrameworkCore;
using System;
using TheBestCloth.BLL.ModelDatabase;

namespace TheBestCloth.DAL.Data
{
    public class PostgresContext: DbContext
    {
        public PostgresContext(DbContextOptions opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShoppingItemConfiguration());
        }

        public DbSet<ShoppingItem> ShoppingItems { get; set; }
        public DbSet<Photo> Photos { get; set; }

        internal object FirstOrDefault()
        {
            throw new NotImplementedException();
        }
    }
}
