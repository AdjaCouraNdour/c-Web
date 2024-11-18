using GestionBoutiqueC.Core;
using GestionBoutiqueC.Entities;


namespace GestionBoutiqueC.Models.Interfaces
{
    public interface IDetailsModel : IModel<Detail>
    {   
        IEnumerable<Detail> GetDetails();
        Task<List<Detail>?> FindArticleByDetteId(int detteId);
    }
}
