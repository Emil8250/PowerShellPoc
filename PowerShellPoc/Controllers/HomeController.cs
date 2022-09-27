using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using Microsoft.AspNetCore.Mvc;
using PowerShellPoc.Models;

namespace PowerShellPoc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        using var ps = PowerShell.Create();
        var results = ps.AddScript("Write-Output 'test';" +
                                   "Write-Output 'test2'").Invoke().ToList();

        return View(results);
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