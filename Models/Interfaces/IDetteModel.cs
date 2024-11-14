using GestionBoutiqueC.Core;
using GestionBoutiqueC.Entities;
using System.Threading.Tasks;

namespace GestionBoutiqueC.Models.Interfaces
{
    public interface IDetteModel : IModel<Dette>
    {
        IEnumerable<Dette> GetDettes();
        Task<List<Dette>> FindByClientId(int ClientId);

    }
}
