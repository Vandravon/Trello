using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Trellov2.Models;

namespace Trellov2.Controllers
{
    public class ConnexionController : Controller
    {
        public static bool userConnected { get; set; } = false; // Modifie ce qu'on affiche dans la Nav bar
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
                HttpContext.Session.SetInt32("UserId", utilisateurTmp.IdUtilisateur); // Créé la variable de session UserId et lui donne la valeur de l'IdUtilisateur de l'objet
                userConnected = true; // Change la Nav bar en affichant la Déconnexion
                return RedirectToAction("Index", "Projet");
            }
            else
            {
                Console.WriteLine("Connexion échouée");
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Deconnexion()
        {
            userConnected = false; // Permet de remettre la Nav bar dans son état initial
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("ProjetId");
            return RedirectToAction("Index", "Home");
        }

        public bool IsConnected() { return userConnected; } // Méthode de test
    }
}
