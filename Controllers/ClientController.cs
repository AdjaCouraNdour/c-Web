using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionBoutiqueC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientModel _clientModel;
        private readonly IDetteModel _detteModel;

        public IActionResult Index()
        {
            var clients = _clientModel.GetClients();
            return View(clients);
        }
        // Injecter le modèle client (le service ClientModel)
        public ClientController(IClientModel clientModel ,IDetteModel detteModel)
        {
            _clientModel = clientModel;
            _detteModel = detteModel;

        }

        // Action pour lister tous les clients
        public async Task<IActionResult> kiki()
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

        // Action pour afficher le formulaire de création d'un client
        public IActionResult Create()
        {
            return View();
        }

        // Action pour enregistrer un client (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Client client)
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

        // public async Task<IActionResult> DetteClient(int clientId)
        // {
        //     var client = await _clientModel.FindById(clientId); // Remplacez par le service ou méthode adaptée
        //     var dettes = await _detteModel.FindByClientId(clientId);
            
        //     ViewBag.Client = client;
        //     return View(dettes);
        // }


    }

}
