using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionBoutiqueC.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleModel _articleModel;
        
        // public IActionResult Index()
        // {
        //     var articles = _articleModel.GetArticles();
        //     return View(articles);
        // }
        // Injecter le modèle article (le service articleModel)
        public ArticleController(IArticleModel articleModel)
        {
            _articleModel = articleModel;
        }

    public IActionResult Index(int page = 1, int limit = 3)
        {
            // Récupérer tous les articles
            var articles = _articleModel.GetArticles()
                          .OrderBy(c => c.Libelle) // Optionnel : tri par nom
                          .Skip((page - 1) * limit) // Ignorer les éléments des pages précédentes
                          .Take(limit) // Prendre uniquement les éléments pour la page courante
                          .ToList();

            // Calcul pour la pagination
            int totalArticles = articles.Count();
            var articlesPaginated = articles.Skip((page - 1) * limit).Take(limit).ToList();

            // Passer les données nécessaires à la vue
            ViewBag.Page = page;
            ViewBag.limit = limit;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalArticles / limit);

            return View(articlesPaginated);
        }

        // Action pour lister tous les articles
        public async Task<IActionResult> kiki()
        {
            var articles = await _articleModel.FindAll();
            return View(articles); // Retourner la vue avec la liste des articles
        }

        // Action pour afficher les détails d'un article par son ID
        public async Task<IActionResult> Details(int id)
        {
            var article = await _articleModel.FindById(id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article); // Retourner la vue de détails
        }

        // Action pour afficher le formulaire de création d'un article
        public IActionResult Create()
        {
            return View();
        }

        // Action pour enregistrer un article (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Article article)
        {
            if (ModelState.IsValid)
            {
                await _articleModel.Save(article);
                return RedirectToAction(nameof(Index)); // Rediriger vers la liste des articles après enregistrement
            }
            return View(article); // Retourner la vue avec le formulaire si la validation échoue
        }

        // Action pour afficher le formulaire d'édition d'un article
        public async Task<IActionResult> Edit(int id)
        {
            var article = await _articleModel.FindById(id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article); // Retourner la vue d'édition
        }

        // Action pour mettre à jour un article (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _articleModel.Update(article);
                return RedirectToAction(nameof(Index)); // Rediriger vers la liste des articles après mise à jour
            }
            return View(article); // Retourner la vue avec les informations de l'édition
        }

        // Action pour supprimer un article
        public async Task<IActionResult> Delete(int id)
        {
            var article = await _articleModel.FindById(id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article); // Retourner la vue de confirmation de suppression
        }

        // Action pour supprimer un article (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _articleModel.Delete(id);
            return RedirectToAction(nameof(Index)); // Rediriger vers la liste des articles après suppression
        }
    }
}
