using System;
using GestionBoutiqueC.Data;
using GestionBoutiqueC.Entities;
namespace GestionBoutiqueC.Fixtures
{
    public  class ArticleDetteFixture
    {
        private readonly ApplicationDbContext _context;

        public ArticleDetteFixture(ApplicationDbContext context)
        {
            _context = context;
        }

        public static List<ArticleDette> GetArticlesDette()
        {
            return new List<ArticleDette>
            {
                new ArticleDette { 
                    // Article = _context.Articles.Find(1)!, 
                    // Dette = _context.Dettes.Find(1)!, 
                    ArticleId = 1,
                    DetteId = 1, 
                    Quantity = 15, 
                    PrixUnitaire = 680 
                    },

            };
        }
    }
}