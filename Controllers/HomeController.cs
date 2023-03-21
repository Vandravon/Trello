using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trellov2.Models;

namespace Trellov2.Controllers;

public class HomeController : Controller
{

    public TrelloContext context = new();


    public HomeController()
    {
        
    }

    public IActionResult Index()
    {
        ConnexionController.userConnected = false; // Permet de remettre la Nav bar dans son état initial
        HttpContext.Session.Remove("UserId");
        HttpContext.Session.Remove("ProjetId");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
