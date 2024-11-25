using GestionBoutiqueC.Core;
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

       public async Task<Dette> Create(int clientId, Dette dette)
        {
            // Récupérer le client pour valider qu'il existe
            var client = await _context.Clients.FindAsync(clientId);
            if (client == null)
            {
                // Si le client n'existe pas, vous pouvez gérer l'erreur ici (par exemple, lever une exception ou retourner null)
                throw new Exception("Client non trouvé.");
            }

            // Associer la dette au client
            dette.ClientId = clientId;
            dette.Client = client; // Si la relation entre Dette et Client est définie

            // Ajouter la dette au contexte
            _context.Dettes.Add(dette);

            // Sauvegarder les modifications dans la base de données
            await _context.SaveChangesAsync();

            return dette; // Retourner la dette créée
        }

        public Task<Dette> Create(Dette data)
        {
            throw new NotImplementedException();
        }
         public async Task<PaginationDetteModel> GetDettesClientByPaginate(int clientId, int page, int pageSize)
        {
            var dettes = _context.Dettes.Where(dette => dette.ClientId == clientId).AsQueryable<Dette>();
            var client = await _context.Clients.SingleAsync<Client>(client => client.Id == clientId)!;
            return await PaginationDetteModel.PaginateDette(dettes, pageSize, page, client);
        }
    }
}
