using Microsoft.EntityFrameworkCore;
using RestApi.Domain.Models;
namespace RestApi.Persistence.PostgreEF
{
    public class ProdutoContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<Produto>().ToTable("produto");
            modelBuilder.Entity<Produto>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Produto>().Property(x => x.Nome).HasColumnName("nome");
            modelBuilder.Entity<Produto>().Property(x => x.Preco).HasColumnName("preco");            
        }        
    }
}