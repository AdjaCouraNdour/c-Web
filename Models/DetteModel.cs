using GestionBoutiqueC.Data;
using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace GestionBoutiqueC.Models
{
    public class DetteModel : IDetteModel
    {
        private readonly ApplicationDbContext _context;

        // Injecter le contexte de la base de données dans le service
        public DetteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Dette> GetDettes()
        {
            return _context.Dettes.ToList();
        }
        // Implémentation de la méthode Delete
        public async Task Delete(int id)
        {
            var dette = await _context.Dettes.FindAsync(id);
            if (dette != null)
            {
                _context.Dettes.Remove(dette);
                await _context.SaveChangesAsync();
            }
        }

        // Implémentation de la méthode FindAll
        public async Task<List<Dette>> FindAll()
        {
            return await _context.Dettes.ToListAsync();
        }

        // Implémentation de la méthode FindById
        public async Task<Dette> FindById(int id)
        {
            return await _context.Dettes.FindAsync(id);
        }

        // Implémentation de la méthode Save
        public async Task Save(Dette data)
        {
            await _context.Dettes.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        // Implémentation de la méthode Update
        public async Task Update(Dette data)
        {
            var existingDette = await _context.Dettes.FindAsync(data.Id);
            if (existingDette != null)
            {
                _context.Entry(existingDette).CurrentValues.SetValues(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Dette>?> FindByClientId(int client)
        {
            return await _context.Dettes
                .Where(d => d.ClientId == client) 
                .ToListAsync();
        }

        public async Task<Dette> Create(Dette dette)
        {

            _context.Dettes.Add(dette);
            await _context.SaveChangesAsync();
            return dette;
        }
    }
}
