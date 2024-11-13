using Microsoft.EntityFrameworkCore;
using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Fixtures;
using Microsoft.EntityFrameworkCore.Diagnostics; // Assurez-vous d'importer le namespace de la classe fixture

namespace GestionBoutiqueC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Dette> Dettes { get; set; }

        // Autres DbSet pour d'autres entités

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => 
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relation 1:1 entre Client et User



            // modelBuilder.Entity<Client>()
            //     .HasOne(c => c.User)
            //     .WithOne(u => u.Client)
            //     .HasForeignKey<User>(u => u.ClientId) // Assurez-vous que ClientId existe dans User
            //     .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Client)
                .WithOne(c => c.User)
                .HasForeignKey<Client>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            // Relation 1:N entre Client et Dette
            modelBuilder.Entity<Dette>()
                .HasOne(d => d.Client)
                .WithMany(c => c.Dettes)
                .HasForeignKey(d => d.ClientId) // Assurez-vous que ClientId existe dans Dette
                .OnDelete(DeleteBehavior.Cascade);

            // Ajout des fixtures
            modelBuilder.Entity<Client>().HasData(ClientFixture.GetClients());
            modelBuilder.Entity<User>().HasData(UserFixture.GetUsers().ToArray());
            modelBuilder.Entity<Dette>().HasData(DetteFixture.GetDettes().ToArray());

            base.OnModelCreating(modelBuilder);
        }
    }
}
