using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionBoutiqueC.Controllers
{
    public class PaiementController : Controller
    {
        private readonly IPaiementModel _paiementModel;
        
        public IActionResult Index()
        {
            var paiements = _paiementModel.GetPaiements();
            return View(paiements);
        }
        // Injecter le modèle paiement (le service paiementModel)
        public PaiementController(IPaiementModel paiementModel)
        {
            _paiementModel = paiementModel;
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

            return View(paiement); // Retourner la vue de confirmation de suppression
        }

        // Action pour supprimer un paiement (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _paiementModel.Delete(id);
            return RedirectToAction(nameof(Index)); // Rediriger vers la liste des paiements après suppression
        }


    }
}
