using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TheGarden.MVCUI.Models;
using TheGarden.DL;
using TheGarden.BL;


namespace TheGarden.MVCUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepository _repo;

    public HomeController(IRepository repo, ILogger<HomeController> logger)
    {
        _logger = logger;
        _repo = repo;
    }

    public async Task<IActionResult> Index()
    {
        // Get the data
        IEnumerable<Plant> plants = await _repo.GetAllPlantsAsync();
        return View(plants);
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
