using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MeuServico.Domain.Entities;

namespace MeuServico.Infrastructure.Data
{
    // Herdando de IdentityDbContext em vez de DbContext puro
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Tarefa>  Tarefas  => Set<Tarefa>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Primeiro aplica toda a configuração do Identity
            base.OnModelCreating(builder);

            // Aqui você pode ajustar nomes de tabelas se quiser, 
            // por exemplo para prefixar ou renomear:
            // builder.Entity<IdentityUser>(b => { b.ToTable("Usuarios"); });
            // builder.Entity<IdentityRole>(b => { b.ToTable("Papeis"); });
            // builder.Entity<IdentityUserRole<string>>(b => { b.ToTable("UsuarioPapeis"); });
            // …

            // Depois, aplicar configurações específicas das suas entidades:
            builder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nome)
                      .IsRequired()
                      .HasMaxLength(100);
                // outras regras de Cliente…
            });

            builder.Entity<Tarefa>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Titulo)
                      .IsRequired()
                      .HasMaxLength(200);
                entity.HasOne(t => t.Cliente)
                      .WithMany(c => c.Tarefas)
                      .HasForeignKey(t => t.ClienteId);
                // outras regras de Tarefa…
            });
        }
    }
}
