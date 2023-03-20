using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trellov2.Models;

namespace Trellov2.Controllers
{
    public class ProjetController : Controller
    {
        readonly TrelloContext context = new();

        public ProjetController() { }

        [HttpGet]
        public IActionResult Index()
        {
            List<Projet> list = new();
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
            Utilisateur utilisateur = context.Utilisateurs.Include(utilisateur => utilisateur.ProjetUtilisateurs)
            .ThenInclude(projetUtilisateur => projetUtilisateur.projetNav)
            .First(x => x.IdUtilisateur == HttpContext.Session.GetInt32("UserId"));
            return View(utilisateur);
            }
            else return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Index(int idProjet)
        {
            HttpContext.Session.SetInt32("ProjetId", idProjet);
            return RedirectToAction("Index", "Liste");
        }
    }
}
