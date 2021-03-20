using Microsoft.EntityFrameworkCore;
using Size.Core.Entidade;

namespace Size.Data
{
    public class SizeDbContext : DbContext
    {
        public SizeDbContext(DbContextOptions<SizeDbContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Conta> Conta { get; set; }

        public DbSet<HistoricoTransacao> HistoricosTransacoes { get; set; }

        public DbSet<Documento> Documento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
