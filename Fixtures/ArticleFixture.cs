using System;
using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Enums;
namespace GestionBoutiqueC.Fixtures
{
    public static class ArticleFixture
    {
        public static List<Article> GetArticles()
        {
            return new List<Article>
            {
                new Article{
                    Id = 1,
                    Libelle = "Bonbon Jina",
                    Prix = 100,
                    QteStock = 50,
                    EtatArticle = EtatArticle.Disponible,
                    Reference = $"A{1:D5}"
                }
            };
        }
    }
}