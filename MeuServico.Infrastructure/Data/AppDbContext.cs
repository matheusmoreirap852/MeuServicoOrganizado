using Microsoft.EntityFrameworkCore;
using MeuServico.Domain.Entities;

namespace MeuServico.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
    }
}