using GestionBoutiqueC.Entities;
using GestionBoutiqueC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionBoutiqueC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserModel _userModel;
    
        public UserController(IUserModel userModel)
        {
            _userModel = userModel;
        }
         public IActionResult Index(int page = 1, int limit = 3)
        {
            // Récupérer tous les users
            var users = _userModel.GetUsers()
                          .OrderBy(c => c.Id) // Optionnel : tri par nom
                          .Skip((page - 1) * limit) // Ignorer les éléments des pages précédentes
                          .Take(limit) // Prendre uniquement les éléments pour la page courante
                          .ToList();

            // Calcul pour la pagination
            int totalUsers = users.Count();
            var usersPaginated = users.Skip((page - 1) * limit).Take(limit).ToList();

            // Passer les données nécessaires à la vue
            ViewBag.Page = page;
            ViewBag.limit = limit;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalUsers / limit);

            return View(usersPaginated);
        }

         [HttpGet]
        public IActionResult FormUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormUser([Bind("Id,Login,Email,Password,Actif,UserRole")] User user)
        {
            if (ModelState.IsValid)
            {
                var userAdded = await _userModel.Create(user);
                TempData["Message"] = "user créé avec succès!";
                return RedirectToAction(nameof(Index));

            }
            return View(user);
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
                await _userModel.Create(user);
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
