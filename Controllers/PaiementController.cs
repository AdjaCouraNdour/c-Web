using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionBoutiqueC.Controllers
{
    public class PaiementController : Controller
    {
        private readonly IPaiementModel _paiementModel;
        private readonly IDetteModel _detteModel;

        
        // Injecter le modèle paiement (le service paiementModel)
        public PaiementController(IPaiementModel paiementModel,IDetteModel detteModel)
        {
            _paiementModel = paiementModel;
            _detteModel = detteModel;

        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 3)
        {
            // Fetch paiements from the service
            var paiements = await _paiementModel.GetPaiementsByPaginate(page, pageSize);
            // Pass the paiements to the view
            return View(paiements);
        }
        // Action pour afficher les détails d'un paiement par son ID
        public async Task<IActionResult> Details(int id)
        {
            var paiement = await _paiementModel.FindById(id);
            if (paiement == null)
            {
                return NotFound();
            }

            return View(paiement); // Retourner la vue de détails
        }

        // Action pour afficher le formulaire de création d'un paiement
        public IActionResult Create()
        {
            return View();
        }

        // Action pour enregistrer un paiement (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                await _paiementModel.Create(paiement);
                return RedirectToAction(nameof(Index)); // Rediriger vers la liste des paiements après enregistrement
            }
            return View(paiement); // Retourner la vue avec le formulaire si la validation échoue
        }

        // Action pour afficher le formulaire d'édition d'un paiement
        public async Task<IActionResult> Edit(int id)
        {
            var paiement = await _paiementModel.FindById(id);
            if (paiement == null)
            {
                return NotFound();
            }

            return View(paiement); // Retourner la vue d'édition
        }

        // Action pour mettre à jour un paiement (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Paiement paiement)
        {
            if (id != paiement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _paiementModel.Update(paiement);
                return RedirectToAction(nameof(Index)); // Rediriger vers la liste des paiements après mise à jour
            }
            return View(paiement); // Retourner la vue avec les informations de l'édition
        }

        // Action pour supprimer un paiement
        public async Task<IActionResult> Delete(int id)
        {
            var paiement = await _paiementModel.FindById(id);
            if (paiement == null)
            {
                return NotFound();
            }

            await _paiementModel.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    
        public async Task<IActionResult> PaiementsDette(int Id)
        {
             var paiementsDette = await _paiementModel.GetPaiementsDette(Id);         

            return View(paiementsDette);
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
                return RedirectToAction("DettesClient", "Dette");
            }

            return View(paiement);
        }

    }
}
