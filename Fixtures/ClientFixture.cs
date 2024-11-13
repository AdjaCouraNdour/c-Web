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
            };
        }
    }
}
