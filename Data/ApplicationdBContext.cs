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
        public DbSet<Detail> Details { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleDette> ArticlesDette { get; set; }
        public DbSet<Paiement> Paiements { get; set; }

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
                .HasForeignKey(d => d.ClientId) 
                .OnDelete(DeleteBehavior.Cascade);

            // Relation N:1 entre Client et Dette
            modelBuilder.Entity<Dette>()
                .HasMany(d => d.Details)
                .WithOne(de => de.Dette)
                .HasForeignKey(de => de.DetteId) 
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Dette>()
                .HasMany(d => d.Paiements)
                .WithOne(p => p.Dette)
                .HasForeignKey(p => p.DetteId) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Article>()
                .HasMany(a => a.Details)
                .WithOne(de => de.Article)
                .HasForeignKey(de => de.ArticleId) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ArticleDette>()
                .HasKey(e => new {
                    e.ArticleId,
                    e.DetteId
                });

            modelBuilder.Entity<ArticleDette>()
                .HasOne(ad => ad.Article)
                .WithMany(a => a.ArticlesDette)
                // Associer la clé étrangère à la colonne DetteId dans la table ArticleDettes
                .HasForeignKey(ad => ad.ArticleId);  // Associer la clé étrangère à la colonne ArticleId dans la table ArticleDettes

            modelBuilder.Entity<ArticleDette>()
                .HasOne(ad => ad.Dette)
                .WithMany(a => a.ArticlesDette)
                .HasForeignKey(ad => ad.DetteId);

            // Ajout des fixtures
            modelBuilder.Entity<Client>().HasData(ClientFixture.GetClients().ToArray());
            modelBuilder.Entity<User>().HasData(UserFixture.GetUsers().ToArray());
            modelBuilder.Entity<Dette>().HasData(DetteFixture.GetDettes().ToArray());
            modelBuilder.Entity<Detail>().HasData(DetailFixture.GetDetails().ToArray());
            modelBuilder.Entity<Article>().HasData(ArticleFixture.GetArticles().ToArray());
            modelBuilder.Entity<Paiement>().HasData(PaiementFixture.GetPaiements().ToArray());
            modelBuilder.Entity<ArticleDette>().HasData(ArticleDetteFixture.GetArticlesDette().ToArray());

            base.OnModelCreating(modelBuilder);
        }
    }
}
