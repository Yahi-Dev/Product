using Microsoft.EntityFrameworkCore;
using Product.Core.Domain.Entities;
using System.Text.RegularExpressions;

namespace Product.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> optiones) : base(optiones) { }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Producto
            modelBuilder.Entity<Producto>().ToTable("Productos");

            modelBuilder.Entity<Producto>().HasKey(producto => producto.ProductID);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
