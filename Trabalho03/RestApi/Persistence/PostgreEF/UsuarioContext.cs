using Microsoft.EntityFrameworkCore;
using RestApi.Domain.Models;
namespace RestApi.Persistence.PostgreEF
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<Usuario>().ToTable("usuario");
            modelBuilder.Entity<Usuario>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Usuario>().Property(x => x.Login).HasColumnName("login");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnName("senha");
        }        
    }
}