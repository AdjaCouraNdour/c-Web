using System;
using GestionBoutiqueC.Entities;
namespace GestionBoutiqueC.Fixtures
{
    public static class PaiementFixture
    {
        public static List<Paiement> GetPaiements()
        {
        return new List<Paiement>
            {
                new Paiement
                {
                    Id = 1,
                    Montant = 200,
                    DetteId = 1, 
                    Date = DateTime.Now
                },
            };
        }
    }
}