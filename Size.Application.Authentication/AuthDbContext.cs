using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Size.Data.Models;

namespace Size.Data
{
    public class AuthDbContext : IdentityDbContext<Usuario>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioConfiguration());
        }
    }
}
