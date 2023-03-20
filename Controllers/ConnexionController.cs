using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Trellov2.Models;

namespace Trellov2.Controllers
{
    public class ConnexionController : Controller
    {
        static bool _userConnected { get; set; } = false;
        public ConnexionController() { }

        [HttpGet]
        public IActionResult Connexion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Connexion(string email, string motDePasse)
        {
            TrelloContext context = new();
            Utilisateur utilisateurTmp = context.Utilisateurs.FirstOrDefault(x => x.AdresseEmail == email && x.MotDePasse == motDePasse)!;
            if (utilisateurTmp!= null) 
            {
                Console.WriteLine("Connexion réussie");
                HttpContext.Session.SetInt32("UserId", utilisateurTmp.IdUtilisateur);
                _userConnected = true;
                return RedirectToAction("Index", "Projet");
            }
            else
            {
                Console.WriteLine(email);
                Console.WriteLine(motDePasse);
                Console.WriteLine("Connexion échouée");
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Deconnexion()
        {
            _userConnected = false;
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("ProjetId");
            return RedirectToAction("Index", "Home");
        }

        public bool IsConnected() { return _userConnected; }
    }
}
