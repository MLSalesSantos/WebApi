using MgnWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MgnWebApi.Context {
    public class ClienteContext : DbContext {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefones> Telefones { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

         protected ClienteContext(DbContextOptions<ClienteContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
        }
    }
}