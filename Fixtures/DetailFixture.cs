using System;
using GestionBoutiqueC.Entities;

namespace GestionBoutiqueC.Fixtures
{
    public static class DetailFixture
    {
        public static List<Detail> GetDetails()
        {
            return new List<Detail>
            {
                new Detail{
                    Id = 1,
                    QteDette = 5,
                    ArticleId = 1,
                    DetteId = 1 
                },
                 new Detail{
                    Id = 2,
                    QteDette = 5,
                    ArticleId = 1,
                    DetteId = 2 
                },
                 new Detail{
                    Id = 3,
                    QteDette = 5,
                    ArticleId = 1,
                    DetteId = 3 
                },
                 new Detail{
                    Id = 4,
                    QteDette = 5,
                    ArticleId = 1,
                    DetteId = 4 
                },
            };
        }
    }
}