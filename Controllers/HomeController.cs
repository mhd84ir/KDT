using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KDT.Models;

namespace KDT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // SendMessage();
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


    // public void SendMessage()
    // {
    //     var sender = "1000689696";
    //     var receptor = "09016250035";
    //     var message = ".وب سرویس پیام کوتاه کاوه نگار";
    //     var api = new kavenegar.KavenegarApi("4E5569537A4C444D316733766E646479717667396153624A7A6D704C5261633967374143694536626B4B513D");
    //     api.Send(sender, receptor, message);
    // }
}
