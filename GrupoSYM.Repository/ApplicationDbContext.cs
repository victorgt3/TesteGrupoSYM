using GrupoSYM.Repository.DependencyInjection;
using GrupoSYM.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrupoSYM.Repository
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidatos> Candidatos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DependencyInjectionSupport.ConfigureOptionsBuilder(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidatos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
