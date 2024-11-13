using System;
using System.Collections.Generic;
using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Enums;

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
                    UserRole = UserRole.Client,
                    ClientId = 1 
                }
            };
        }
    }
}
