using GestionBoutiqueC.Data;
using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace GestionBoutiqueC.Models
{
    public class ClientModel : IClientModel
    {
        private readonly ApplicationDbContext _context;

        // Injecter le contexte de la base de données dans le service
        public ClientModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Client> GetClients()
        {
            return _context.Clients.ToList();
        }
        // Implémentation de la méthode Delete
        public async Task Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        // Implémentation de la méthode FindAll
        public async Task<List<Client>> FindAll()
        {
            return await _context.Clients.ToListAsync();
        }

        // Implémentation de la méthode FindById
        public async Task<Client> FindById(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        // Implémentation de la méthode FindByTelephone
        public async Task<Client> FindByTelephone(string telephone)
        {
            return await _context.Clients
                .FirstOrDefaultAsync(c => c.Telephone == telephone);
        }

        // Implémentation de la méthode Save
        public async Task Save(Client data)
        {
            await _context.Clients.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        // Implémentation de la méthode Update
        public async Task Update(Client data)
        {
            var existingClient = await _context.Clients.FindAsync(data.Id);
            if (existingClient != null)
            {
                _context.Entry(existingClient).CurrentValues.SetValues(data);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Client> Create(Client client)
        {

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }
        // public async Task<PaginationModel<Client>> GetClientsByPaginate(int page, int pageSize)
        // {
        //     var clients = _context.Clients.AsQueryable<Client>();
        //     return await PaginationModel<Client>.Paginate(clients, pageSize, page);

        // }
    }
}
