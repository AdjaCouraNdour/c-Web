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
                },
                 new User
                {
                    Id = 2,
                    Login = "boutiquier",
                    Email = "boutiquier@example.com",
                    Password = "boutiquier",
                    Actif = true,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    UserRole = UserRole.Client,
                    ClientId = 2
                },
                 new User
                {
                    Id = 3,
                    Login = "client",
                    Email = "client@example.com",
                    Password = "client",
                    Actif = true,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    UserRole = UserRole.Client,
                    ClientId = 3
                },
                 new User
                {
                    Id = 4,
                    Login = "padma",
                    Email = "padma@example.com",
                    Password = "padma",
                    Actif = true,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    UserRole = UserRole.Client,
                    ClientId = 4 
                }
            };
        }
    }
}
