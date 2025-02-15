using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Notifications;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController(IEmail email) : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly IEmail _eMail = email;

        public IActionResult Index()
        {
            if (!_eMail.IsSent)
            {
                _eMail.Destiny = "jonico.dorico@gmail.com";
                _eMail.Subject = "Portfolio visit";
                _eMail.Message = $"You has a visitor to your portfolio";
                _eMail.Send();
            }
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
}
