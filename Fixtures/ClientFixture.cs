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
                new Client { Id = 2, Surnom = "coura", Telephone = "77479944", Address = "456 Rue de Lyon",UserId = 2, },
                new Client { Id = 3, Surnom = "loulou", Telephone = "774799473", Address = "789 Rue de Marseille",UserId = 3, }
            };
        }
    }
}
