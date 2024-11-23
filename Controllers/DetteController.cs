using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Enums;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace GestionBoutiqueC.Controllers
{
    public class DetteController : Controller
    {
        private readonly IDetteModel _detteModel;
        private readonly IDetailsModel _detailsModel;
        private readonly IPaiementModel _paiementModel;
        private readonly IClientModel _clientModel;
        private readonly IArticleModel _articleModel;

        public DetteController(IDetteModel detteModel, IDetailsModel detailsModel, IPaiementModel paiementModel, IClientModel clientModel,IArticleModel articleModel)
        {
            _detteModel = detteModel;
            _detailsModel = detailsModel;
            _paiementModel = paiementModel;
            _clientModel = clientModel;
            _articleModel=articleModel;
        }

        // Action pour afficher la liste des dettes avec pagination
        public IActionResult Index(int page = 1, int limit = 3)
        {
            var dettes = _detteModel.GetDettes()
                          .OrderBy(c => c.Id)
                          .Skip((page - 1) * limit)
                          .Take(limit)
                          .ToList();

            int totalDettes = dettes.Count();
            var dettesPaginated = dettes.Skip((page - 1) * limit).Take(limit).ToList();

            ViewBag.Page = page;
            ViewBag.limit = limit;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalDettes / limit);

            return View(dettesPaginated);
        }
    //     public IActionResult Index(int page = 1, int limit = 10)
    // {
    //     var dettes = _context.Dettes.Skip((page - 1) * limit).Take(limit).ToList();
    //     var totalCount = _context.Dettes.Count();

    //     ViewBag.Page = page;
    //     ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / limit);
    //     ViewBag.Limit = limit;

    //     return View(dettes);
    // }

        // Action pour afficher les détails d'une dette
        public async Task<IActionResult> Details(int id)
        {
            var dette = await _detteModel.FindById(id);
            if (dette == null)
            {
                return NotFound();
            }
            return View(dette);
        }

        // Action pour afficher le formulaire de création d'une dette
        public async Task<IActionResult> FormDette(int clientId)
        {
            var client = await _clientModel.FindById(clientId);
            if (client == null)
            {
                return NotFound();
            }

            // Récupérer la liste des articles disponibles
            var articles = _articleModel.GetArticles();
            ViewBag.Articles = articles;

            ViewBag.Client = client;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormDette(int clientId, List<ArticleSelection> articleSelections)
        {
            if (ModelState.IsValid)
            {
                // Trouver le client associé
                var client = await _clientModel.FindById(clientId);
                if (client == null)
                {
                    return NotFound();
                }

                // Créer une nouvelle dette
                var dette = new Dette
                {
                    ClientId = clientId,
                    Details = new List<Detail>() // Initialisation de la liste des détails
                };

                // Ajouter chaque article sélectionné à la dette en créant des détails
                foreach (var selection in articleSelections)
                {
                    var article = await _articleModel.FindById(selection.ArticleId); // Find the article
                    if (article != null)
                    {
                        var detail = new Detail
                        {
                            ArticleId = selection.ArticleId,
                            QteDette = selection.Quantity,
                            Dette = dette // Link the detail to the debt
                        };

                        dette.Details.Add(detail); // Add the detail to the debt's details list
                        dette.Montant += selection.Quantity * article.Prix; // Add to the total debt amount
                    }
                }


                // Calculer le montant total de la dette

                // Sauvegarder la dette et ses détails
                await _detteModel.Create(clientId, dette);
                TempData["Message"] = "Dette créée avec succès!";
                return RedirectToAction("Index", "Client");
            }

            return View();
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> FormDette(int clientId, Dette dette, string selectedArticles)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         // Désérialiser les articles sélectionnés
        //         var articles = JsonConverter.DeserializeObject<List<ArticleSelection>>(selectedArticles);

        //         // Ajouter chaque article à la dette
        //         foreach (var item in articles)
        //         {
        //             var article = await _articleModel.FindById(item.ArticleId);
        //             if (article != null)
        //             {
        //                 // Logique pour associer l'article à la dette
        //                 var detail = new Detail
        //                 {
        //                     ArticleId = item.ArticleId,
        //                     QteDette = item.Quantity,
        //                     DetteId = dette.Id
        //                 };

        //                 await _detailsModel.Create(detail); // Sauvegarde du détail
        //             }
        //         }

        //         // Sauvegarder la dette elle-même
        //         await _detteModel.Create(clientId, dette);
        //         TempData["Message"] = "Dette créée avec succès!";
        //         return RedirectToAction("Index", "Client");
        //     }

        //     return View(dette);
        // }

// Classe pour lier les articles et la quantité
        public class ArticleSelection
        {
            public int ArticleId { get; set; }
            public int Quantity { get; set; }
        }

        // Action pour éditer une dette
        public async Task<IActionResult> Edit(int id)
        {
            var dette = await _detteModel.FindById(id);
            if (dette == null)
            {
                return NotFound();
            }
            return View(dette);
        }

        // Action pour mettre à jour une dette
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
                return RedirectToAction(nameof(Index));
            }
            return View(dette);
        }

        [HttpPost]
        public async Task<IActionResult> Accepte(int detteId)
        {
            // Rechercher la dette par ID
            var dette = await _detteModel.FindById(detteId);
            if (dette == null)
            {
                return NotFound();
            }

            // Mettre à jour l'état de la dette à "acceptée"
            dette.EtatDette = EtatDette.EnCours;
            _detteModel.Update(dette);

            // Rediriger ou retourner une vue
            return RedirectToAction("Index"); // Remplacez "Index" par la page que vous souhaitez afficher.
        }

        [HttpPost]
        public async Task<IActionResult> Refuse(int detteId)
        {
            // Rechercher la dette par ID
            var dette = await _detteModel.FindById(detteId);
            if (dette == null)
            {
                return NotFound();
            }

            // Mettre à jour l'état de la dette à "annulée"
            dette.EtatDette = EtatDette.Anuler;
            _detteModel.Update(dette);

            // Rediriger ou retourner une vue
            return RedirectToAction("Index"); // Remplacez "Index" par la page que vous souhaitez afficher.
        }

        // Action pour supprimer une dette
        public async Task<IActionResult> Delete(int id)
        {
            var dette = await _detteModel.FindById(id);
            if (dette == null)
            {
                return NotFound();
            }
            return View(dette);
        }

        // Action pour confirmer la suppression d'une dette
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _detteModel.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // Action pour afficher les paiements d'une dette
        public async Task<IActionResult> FormPaiement(int detteId)
        {
            var dette = await _detteModel.FindById(detteId);
            if (dette == null)
            {
                return NotFound();
            }

            ViewBag.Dette = dette;
            return View(new Paiement { DetteId = dette.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormPaiement([Bind("Montant, DetteId")] Paiement paiement)
        {
            if (!ModelState.IsValid)
            {
                var dette = await _detteModel.FindById(paiement.DetteId);
                ViewBag.Dette = dette;
                return View(paiement);
            }

            var detteToUpdate = await _detteModel.FindById(paiement.DetteId);
            if (detteToUpdate != null)
            {
                await _paiementModel.Create(paiement);
                await _detteModel.Update(detteToUpdate);
                TempData["Message"] = "Paiement enregistré avec succès!";
                return RedirectToAction("Index", "Dette");
            }

            return View(paiement);
        }
    }
}
