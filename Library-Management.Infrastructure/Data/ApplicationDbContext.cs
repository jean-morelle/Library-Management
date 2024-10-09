using Library_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EmpruntLivre>()
        //    .HasOne(p => p.Livre)
        //    .WithMany(p1 => p1.EmpruntLivre)
        //    .HasForeignKey(p2 => p2.LivreId);

        //    modelBuilder.Entity<EmpruntLivre>()
        //   .HasOne(p => p.Emprunt)
        //   .WithMany(p1 => p1.EmpruntLivre)
        //   .HasForeignKey(p2 => p2.EmpruntId);

        //}

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Emprunt> Emprunts { get; set; }

   
    }
}
