using Microsoft.EntityFrameworkCore;
using GestionBoutiqueC.Entities;

namespace GestionBoutiqueC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        // Autres DbSet pour d'autres entités

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
