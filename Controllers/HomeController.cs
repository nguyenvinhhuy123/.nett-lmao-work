using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _nett_lmao_work.Models;

namespace _nett_lmao_work.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index([Bind] Auth auth)
    {
        int res = CheckPassword(auth);
        if (res==1)
        {
            TempData["msg"] = "You are welcome to Admin Section";
            return RedirectToAction("Index", "Student");
        }
        else
        {
            TempData["msg"] = "Admin id or Password is wrong.!";
            return View();
        }
        
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
    private int CheckPassword(Auth auth)
    {
        if (
            auth._adminPassword == "admin" &&
            auth._adminUsername == "admin"
        )
        {
            return 1;
        }
        return 0;
    }

}
