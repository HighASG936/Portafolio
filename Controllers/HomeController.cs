using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Notifications;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController(IEmail email) : Controller
    {
        private readonly IEmail _eMail = email;

        public IActionResult Index()
        {
            if (!_eMail.IsSent)
            {
                _eMail.Destiny = "jonico.dorico@gmail.com";
                _eMail.Subject = "Someone just visited your portfolio!";
                _eMail.Message = "New visit detected on your portfolio.";
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
