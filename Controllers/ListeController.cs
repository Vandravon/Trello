using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trellov2.Models;

namespace Trellov2.Controllers;

public class ListeController : Controller
{

    public TrelloContext context = new();

    public ListeController()
    {
        Console.WriteLine("Liste ok!");
        
    }

    public IActionResult Index()
    {
        Projet projet = context.Projets
            .Include(x => x.IdListes)
            .ThenInclude(x => x.Cartes)
            .First(x => x.IdProjet == HttpContext.Session.GetInt32("ProjetId"));
        return View(projet);
    }

    [HttpGet]
    public IActionResult Add() {
        return View();
    }

    [HttpPost]
    public IActionResult Add(string name) 
    {
        Projet tmpProjet = context.Projets.Single(p => p.IdProjet == HttpContext.Session.GetInt32("ProjetId"));
        Liste tmpListe = new Liste(name, tmpProjet);

        context.Listes.Add(tmpListe);
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        Liste editList = context.Listes.Single(l => l.IdListe == id);
        return View(editList);
    }

    [HttpPost]
    public IActionResult Edit(Liste formResult)
    {
        Liste editList = context.Listes.Single(l => l.IdListe == formResult.IdListe);

        editList.Nom = formResult.Nom;
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Liste listToRemove = context.Listes.Single(l => l.IdListe == id);

        foreach (Carte carte in listToRemove.Cartes)
        {
            context.Cartes.Remove(carte);
        }
        context.Listes.Remove(listToRemove);
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Test()
    {
        Console.WriteLine(HttpContext.Session.GetInt32("UserId").ToString());
        return View();
    }

}
