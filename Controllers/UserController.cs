using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionBoutiqueC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserModel _userModel;
        
        public IActionResult Index()
        {
            var users = _userModel.GetUsers();
            return View(users);
        }
        // Injecter le modèle user (le service userModel)
        public UserController(IUserModel userModel)
        {
            _userModel = userModel;
        }

        // Action pour lister tous les users
        public async Task<IActionResult> kiki()
        {
            var users = await _userModel.FindAll();
            return View(users); // Retourner la vue avec la liste des users
        }

        // Action pour afficher les détails d'un user par son ID
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userModel.FindById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user); // Retourner la vue de détails
        }

        // Action pour afficher le formulaire de création d'un user
        public IActionResult Create()
        {
            return View();
        }

        // Action pour enregistrer un user (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _userModel.Save(user);
                return RedirectToAction(nameof(Index)); // Rediriger vers la liste des users après enregistrement
            }
            return View(user); // Retourner la vue avec le formulaire si la validation échoue
        }

        // Action pour afficher le formulaire d'édition d'un user
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userModel.FindById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user); // Retourner la vue d'édition
        }

        // Action pour mettre à jour un user (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _userModel.Update(user);
                return RedirectToAction(nameof(Index)); // Rediriger vers la liste des users après mise à jour
            }
            return View(user); // Retourner la vue avec les informations de l'édition
        }

        // Action pour supprimer un user
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userModel.FindById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user); // Retourner la vue de confirmation de suppression
        }

        // Action pour supprimer un user (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userModel.Delete(id);
            return RedirectToAction(nameof(Index)); // Rediriger vers la liste des users après suppression
        }
    }
}
