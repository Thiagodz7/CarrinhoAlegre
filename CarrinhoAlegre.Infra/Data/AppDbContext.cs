using CarrinhoAlegre.Core.Models.Produtos;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CarrinhoAlegre.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produtos");
                entity.HasKey(p => p.Id);
            });
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
