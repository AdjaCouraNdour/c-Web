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
            };
        }
    }
}