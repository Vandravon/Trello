using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trellov2.Models;

namespace Trellov2.Controllers;

public class CarteController : Controller
{

    public TrelloContext context = new();

    public CarteController()
    {
        
    }


    [HttpGet]
    public IActionResult Add(int idListe) {
        return View(idListe);
    }

    [HttpPost]
    public IActionResult Add(string titre, string description, int idListe) 
    {
        Liste tmpListe = context.Listes.Single(l => l.IdListe == idListe);
        Carte tmpCarte = new Carte(titre, description, tmpListe);

        context.Cartes.Add(tmpCarte);
        context.SaveChanges();
        return RedirectToAction("Index", "Liste");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        Carte editCard = context.Cartes.Single(c => c.IdCarte == id);
        return View(editCard);
    }

    [HttpPost]
    public IActionResult Edit(Carte formResult)
    {
        Carte editCard = context.Cartes.Single(c => c.IdCarte == formResult.IdCarte);

        editCard.Titre = formResult.Titre;
        editCard.Description = formResult.Description;
        context.SaveChanges();
        return RedirectToAction("Index", "Liste");
    }

    public IActionResult Delete(int id)
    {
        Carte cardToRemove = context.Cartes.Single(c => c.IdCarte == id);

        context.Cartes.Remove(cardToRemove);
        context.SaveChanges();
        return RedirectToAction("Index", "Liste");
    }

}
