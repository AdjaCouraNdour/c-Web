using System;
using System.Collections.Generic;
using GestionBoutiqueC.Entities;

namespace GestionBoutiqueC.Fixtures
{
    public static class DetteFixture
    {
        public static List<Dette> GetDettes()
        {
            return new List<Dette>
            {
                new Dette
                {
                    Id = 1,
                    Date = DateTime.Now.AddMonths(-1),
                    Montant = 500.0,
                    MontantVerse = 200.0,
                    MontantRestant = 300.0,
                    ClientId = 1 // Associer à ClientId 1
                },
                new Dette
                {
                    Id = 3,
                    Date = DateTime.Now.AddMonths(-2),
                    Montant = 1200.0,
                    MontantVerse = 500.0,
                    MontantRestant = 700.0,
                    ClientId = 2 // Associer à ClientId 2
                },
                new Dette
                {
                    Id = 3,
                    Date = DateTime.Now.AddMonths(-3),
                    Montant = 750.0,
                    MontantVerse = 750.0,
                    MontantRestant = 0.0,
                    ClientId = 1 // Associer à ClientId 1
                }
            };
        }
    }
}
