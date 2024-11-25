using GestionBoutiqueC.Core;
using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Enums;


namespace GestionBoutiqueC.Models.Interfaces
{
    public interface IArticleModel : IModel<Article>
    {
        Task<Article> FindByEtat(EtatArticle etat);
        IEnumerable<Article> GetArticles();
        Task<PaginationModel<Article>> GetArticlesByPaginate(int page, int pageSize);

    }
}
