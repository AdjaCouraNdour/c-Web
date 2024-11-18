using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Models;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionBoutiqueC.Controllers
{
    public class DetteController : Controller
    {
        private readonly IDetteModel _detteModel;
        
        // public IActionResult Index()
        // {
        //     var dettes = _detteModel.GetDettes();
        //     return View(dettes);
        // }
        // Injecter le modèle dette (le service detteModel)
        public DetteController(IDetteModel detteModel)
        {
            _detteModel = detteModel;
        }

    public IActionResult Index(int page = 1, int limit = 3)
        {
            // Récupérer tous les dettes
            var dettes = _detteModel.GetDettes()
                          .OrderBy(c => c.Id) // Optionnel : tri par nom
                          .Skip((page - 1) * limit) // Ignorer les éléments des pages précédentes
                          .Take(limit) // Prendre uniquement les éléments pour la page courante
                          .ToList();

            // Calcul pour la pagination
            int totalDettes = dettes.Count();
            var dettesPaginated = dettes.Skip((page - 1) * limit).Take(limit).ToList();

            // Passer les données nécessaires à la vue
            ViewBag.Page = page;
            ViewBag.limit = limit;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalDettes / limit);

            return View(dettesPaginated);
        }
        // Action pour lister tous les dettes
        public async Task<IActionResult> kiki()
        {
            var dettes = await _detteModel.FindAll();
            return View(dettes); // Retourner la vue avec la liste des dettes
        }

        // Action pour afficher les détails d'un dette par son ID
        public async Task<IActionResult> Details(int id)
        {
            var dette = await _detteModel.FindById(id);
            if (dette == null)
            {
                return NotFound();
            }

            return View(dette); // Retourner la vue de détails
        }

        // Action pour afficher le formulaire de création d'un dette
        public IActionResult Create()
        {
            return View();
        }

        // Action pour enregistrer un dette (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dette dette)
        {
            if (ModelState.IsValid)
            {
                await _detteModel.Save(dette);
                return RedirectToAction(nameof(Index)); // Rediriger vers la liste des dettes après enregistrement
            }
            return View(dette); // Retourner la vue avec le formulaire si la validation échoue
        }

        // Action pour afficher le formulaire d'édition d'un dette
        public async Task<IActionResult> Edit(int id)
        {
            var dette = await _detteModel.FindById(id);
            if (dette == null)
            {
                return NotFound();
            }

            return View(dette); // Retourner la vue d'édition
        }

        // Action pour mettre à jour un dette (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Dette dette)
        {
            if (id != dette.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _detteModel.Update(dette);
                return RedirectToAction(nameof(Index)); // Rediriger vers la liste des dettes après mise à jour
            }
            return View(dette); // Retourner la vue avec les informations de l'édition
        }

        // Action pour supprimer un dette
        public async Task<IActionResult> Delete(int id)
        {
            var dette = await _detteModel.FindById(id);
            if (dette == null)
            {
                return NotFound();
            }

            return View(dette); // Retourner la vue de confirmation de suppression
        }

        // Action pour supprimer un dette (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _detteModel.Delete(id);
            return RedirectToAction(nameof(Index)); // Rediriger vers la liste des dettes après suppression
        }
         public async Task<IActionResult> DetailsDette (int detteId)
        {
            var dette = await _detteModel.FindById(detteId);
            if (dette == null)
            {
                return NotFound();
            }
            var articles = dette.Details?.Select(d => d.Article).ToList();
            return View(articles);
        }
    }
}
