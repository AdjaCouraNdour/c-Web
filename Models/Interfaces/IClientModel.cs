using GestionBoutiqueC.Core;
using GestionBoutiqueC.Entities;


namespace GestionBoutiqueC.Models.Interfaces
{
    public interface IClientModel : IModel<Client>
    {
        Task<Client> FindByTelephone(string telephone);
        IEnumerable<Client> GetClients();
        Task<Client> FindBySurnomAndTelephone(string surnom, string telephone);
        Task<PaginationModel<Client>> GetClientsByPaginate(int page, int pageSize);

    }
}
