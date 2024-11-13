using System;
using System.Collections.Generic;
using GestionBoutiqueC.Entities;

namespace GestionBoutiqueC.Fixtures
{
    public static class UserFixture
    {
        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Login = "admin",
                    Email = "admin@example.com",
                    Password = "admin",
                    Actif = true,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    ClientId = 1 // Lier à Client avec Id 1
                },
                new User
                {
                    Id = 2,
                    Login = "user1",
                    Email = "user1@example.com",
                    Password = "user1",
                    Actif = true,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    ClientId = 2 // Lier à Client avec Id 2
                },
                new User
                {
                    Id = 3,
                    Login = "Boutiquier",
                    Email = "Boutiquier@example.com",
                    Password = "Boutiquier",
                    Actif = false,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    ClientId = 3 // Lier à Client avec Id 3
                }
            };
        }
    }
}
