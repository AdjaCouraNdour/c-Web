using System;
using System.Collections.Generic;
using GestionBoutiqueC.Entities;

namespace GestionBoutiqueC.Fixtures
{
    public static class ClientFixture
    {
        public static List<Client> GetClients()
        {
            return new List<Client>
            {
                new Client { Id = 1, Surnom = "kiki", Telephone = "774799479", Address = "123 Rue de Paris",UserId = 1, },
                new Client { Id = 2, Surnom = "Adja Coura", Telephone = "774790479", Address = "123 Rue de Dakar",UserId = 2, },
                new Client { Id = 3, Surnom = "Annha", Telephone = "774799409", Address = " Saint Louis",UserId = 3, },
                new Client { Id = 4, Surnom = "Padama", Telephone = "770009409", Address = " Saint Louis",UserId = 4, },

            };
        }
    }
}
