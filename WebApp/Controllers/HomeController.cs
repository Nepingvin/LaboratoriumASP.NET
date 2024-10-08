using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult About(string op)
    {
        ViewBag.Op = op;
        return View();
    }

    public IActionResult Calculator(string op, double x, double y)
    {
        switch (op)
        {
            case "add":
                ViewBag.Result = x + y;
                break;
            case "sub":
                ViewBag.Result = x - y;
                break;
            case "mul":
                ViewBag.Result = x * y;
                break;
            case "div":
                ViewBag.Result = x / y;
                break;
        }

        return View();
    }
}