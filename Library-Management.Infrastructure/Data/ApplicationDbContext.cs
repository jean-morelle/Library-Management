using Librairi_Management.Domain.Models;
using Library_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Emprunt> Emprunts { get; set; }
        public DbSet<Client>Clients { get; set; }
        public DbSet<Utilisateur>Utilisateurs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emprunt>()
                .HasOne(e => e.Livre)
                  .WithMany(e => e.Emprunts)
                  .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Emprunt>()
                .HasOne(x=>x.Client)
                .WithMany(x=>x.emprunts)
                .OnDelete(DeleteBehavior.Cascade);
            
        }

    }
}
