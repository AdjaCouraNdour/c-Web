using GestionBoutiqueC.Data;
using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestionBoutiqueC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientModel _clientModel;
        private readonly IDetteModel _detteModel;

        public ClientController(IClientModel clientModel, IDetteModel detteModel)
        {
            _clientModel = clientModel;
            _detteModel = detteModel;
        }

        // Action pour afficher la liste des clients avec pagination
        public IActionResult Index(int page = 1, int limit = 3)
        {
            var clients = _clientModel.GetClients()
                          .OrderBy(c => c.Id)
                          .Skip((page - 1) * limit)
                          .Take(limit)
                          .ToList();

            int totalClients = clients.Count();
            var clientsPaginated = clients.Skip((page - 1) * limit).Take(limit).ToList();

            ViewBag.Page = page;
            ViewBag.limit = limit;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalClients / limit);

            return View(clientsPaginated);
        }

        // Action pour afficher le formulaire de création d'un client
        [HttpGet]
        public IActionResult FormClient()
        {
            return View();
        }

        // Action pour ajouter un client
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormClient([Bind("Surnom,Telephone,Address")] Client client)
        {
            if (ModelState.IsValid)
            {
                var clientAdded = await _clientModel.Create(client);
                if (clientAdded != null)
                {
                    TempData["Message"] = "Client créé avec succès!";
                    return RedirectToAction(nameof(Index));  
                }
              
            }
            return View(client);
        }

        // Action pour afficher les détails d'un client
        public async Task<IActionResult> DetailsClient(int id)
        {
            var client = await _clientModel.FindById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // Action pour afficher le formulaire d'édition d'un client
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clientModel.FindById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // Action pour mettre à jour un client
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _clientModel.Update(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // Action pour supprimer un client
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _clientModel.FindById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // Action pour confirmer la suppression d'un client
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clientModel.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // Action pour afficher les dettes d'un client
        public async Task<IActionResult> DetteClient(int client)
        {
            var clientt = await _clientModel.FindById(client);
            if (clientt == null)
            {
                return NotFound();
            }

            var dettes = await _detteModel.FindByClientId(client);

            ViewBag.Client = clientt;
            if (dettes == null || !dettes.Any())
            {
                dettes = new List<Dette>();
            }

            return View(dettes);
        }
        [HttpGet]
        public IActionResult FormClientVal()
        {
            return View();
        }
        // Action pour valider les informations d'un client
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormClientVal(string Surnom, string Telephone)
        {
            if (ModelState.IsValid)
            {
                var client = await _clientModel.FindBySurnomAndTelephone(Surnom, Telephone);
                if (client != null)
                {
                    return RedirectToAction("FormDette", new { clientId = client.Id });
                }
                else
                {
                    ModelState.AddModelError("", "Client non trouvé. Veuillez vérifier les informations.");
                }
            }
            return View();
        }
    }
}
