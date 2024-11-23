using GestionBoutiqueC.Core;
using GestionBoutiqueC.Entities;


namespace GestionBoutiqueC.Models.Interfaces
{
    public interface IPaiementModel : IModel<Paiement>
    {
        IEnumerable<Paiement> GetPaiements();   
        Task<IEnumerable<Paiement>> GetPaiementsDette(int Id);
 }
}
