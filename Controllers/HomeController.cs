using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TranaWarePc.Models;
using TranaWarePc.Services;
using System.Diagnostics;

namespace TranaWarePc.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeService> _homeServiceLogger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeService> homeServiceLogger, IHomeService homeService)
        {
            _homeServiceLogger = homeServiceLogger;
            _homeService = homeService;
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

        [HttpPost]
        public IActionResult Subscribe(string email)
        {
            var subscription = new Newsletter();
            subscription.Email = email;
            _homeService.AddNewsletter(subscription); 
            _homeService.SaveChanges();
            return View();
        }
    }
}
