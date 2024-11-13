using GestionBoutiqueC.Data;
using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Enums;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace GestionBoutiqueC.Models
{
    public class ArticleModel : IArticleModel
    {
        private readonly ApplicationDbContext _context;

        // Injecter le contexte de la base de données dans le service
        public ArticleModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Article> GetArticles()
        {
            return _context.Articles.ToList();
        }
        // Implémentation de la méthode Delete
        public async Task Delete(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }
        }

        // Implémentation de la méthode FindAll
        public async Task<List<Article>> FindAll()
        {
            return await _context.Articles.ToListAsync();
        }

        // Implémentation de la méthode FindById
        public async Task<Article> FindById(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        // Implémentation de la méthode Save
         public async Task Save(Article data)
        {
            await _context.Articles.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        // Implémentation de la méthode Update
        public async Task Update(Article data)
        {
            var existingArticle = await _context.Articles.FindAsync(data.Id);
            if (existingArticle != null)
            {
                _context.Entry(existingArticle).CurrentValues.SetValues(data);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Article> FindByEtat(EtatArticle etat)
        {
            throw new NotImplementedException();
        }
    }
}
