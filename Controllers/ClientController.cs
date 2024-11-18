using GestionBoutiqueC.Data;
using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GestionBoutiqueC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientModel _clientModel;
        private readonly IDetteModel _detteModel;
        // Injecter le modèle client (le service ClientModel)
        public ClientController(IClientModel clientModel, IDetteModel detteModel)
        {
            _clientModel = clientModel;
            _detteModel = detteModel;

        }

        public IActionResult Index(int page = 1, int limit = 3)
        {
            // Récupérer tous les clients
            var clients = _clientModel.GetClients()
                          .OrderBy(c => c.Id) // Optionnel : tri par nom
                          .Skip((page - 1) * limit) // Ignorer les éléments des pages précédentes
                          .Take(limit) // Prendre uniquement les éléments pour la page courante
                          .ToList();

            // Calcul pour la pagination
            int totalClients = clients.Count();
            var clientsPaginated = clients.Skip((page - 1) * limit).Take(limit).ToList();

            // Passer les données nécessaires à la vue
            ViewBag.Page = page;
            ViewBag.limit = limit;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalClients / limit);

            return View(clientsPaginated);
        }
        [HttpGet]
        public IActionResult FormClient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormClient([Bind("Surnom,Telephone,Address")] Client client)
        {
            if (ModelState.IsValid)
            {
                var clientAdded = await _clientModel.Create(client);
                TempData["Message"] = "Client créé avec succès!";
                return RedirectToAction(nameof(Index));

            }
            return View(client);
        }


        // Action pour lister tous les clients
        public async Task<IActionResult> FindAll()
        {
            var clients = await _clientModel.FindAll();
            return View(clients); // Retourner la vue avec la liste des clients
        }



        // Action pour afficher les détails d'un client par son ID
        public async Task<IActionResult> Details(int id)
        {
            var client = await _clientModel.FindById(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client); // Retourner la vue de détails
        }
        // public async Task<IActionResult> FormClient(int id)
        // {
        //     var client = await _clientModel.FindById(id);
        //     if (client == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(client); // Retourner la vue de détails
        // }

        // Action pour afficher le formulaire de création d'un client
        // Action pour enregistrer un client (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateClient(Client client)
        {
            if (ModelState.IsValid)
            {
                await _clientModel.Save(client);
                return RedirectToAction(nameof(Index)); // Rediriger vers la liste des clients après enregistrement
            }
            return View(client); // Retourner la vue avec le formulaire si la validation échoue
        }

        // Action pour afficher le formulaire d'édition d'un client
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clientModel.FindById(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client); // Retourner la vue d'édition
        }

        // Action pour mettre à jour un client (POST)
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
                return RedirectToAction(nameof(Index)); // Rediriger vers la liste des clients après mise à jour
            }
            return View(client); // Retourner la vue avec les informations de l'édition
        }

        // Action pour supprimer un client
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _clientModel.FindById(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client); // Retourner la vue de confirmation de suppression
        }

        // Action pour supprimer un client (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clientModel.Delete(id);
            return RedirectToAction(nameof(Index)); // Rediriger vers la liste des clients après suppression
        }


        public async Task<IActionResult> DetteClient(int client)
        {
            var clientt = await _clientModel.FindById(client);
            if (clientt == null)
            {
                return NotFound(); // Ou une gestion d'erreur personnalisée si le client n'est pas trouvé
            }
            var dettes = await _detteModel.FindByClientId(client);

            ViewBag.Client = clientt;
            if (dettes == null || !dettes.Any())
            {
                dettes = new List<Dette>();
            }

            return View(dettes);
        }



    }

}
