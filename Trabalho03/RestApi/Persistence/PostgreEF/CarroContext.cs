using Microsoft.EntityFrameworkCore;
using RestApi.Domain.Models;
namespace RestApi.Persistence.PostgreEF
{
    public class CarroContext : DbContext
    {
        public DbSet<Carro> Carro { get; set; }
        public CarroContext(DbContextOptions<CarroContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<Carro>().ToTable("carro");
            modelBuilder.Entity<Carro>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Carro>().Property(x => x.Nome).HasColumnName("nome");
            modelBuilder.Entity<Carro>().Property(x => x.Marca).HasColumnName("marca");
            modelBuilder.Entity<Carro>().Property(x => x.Modelo).HasColumnName("modelo");
        }        
    }
}