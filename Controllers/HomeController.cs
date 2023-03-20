using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trellov2.Models;

namespace Trellov2.Controllers;

public class HomeController : Controller
{

    public TrelloContext context = new();


    public HomeController()
    {
        Console.WriteLine("Home ok!");
        
    }

    public IActionResult Index()
    {
        HttpContext.Session.SetInt32("UserId", 0);
        HttpContext.Session.SetInt32("ProjetId", 0);
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
