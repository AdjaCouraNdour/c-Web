using GestionBoutiqueC.Core;
using GestionBoutiqueC.Entities;
using System.Threading.Tasks;

namespace GestionBoutiqueC.Models.Interfaces
{
    public interface IDetteModel : IModel<Dette>
    {
        IEnumerable<Dette> GetDettes();
        Task<List<Dette>> FindByClientId(int ClientId);
        Task<Dette> Create(int clientId, Dette dette);
        Task<PaginationDetteModel> GetDettesClientByPaginate(int clientId, int page, int pageSize);

    }
}
