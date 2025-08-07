using Microsoft.AspNetCore.Mvc;

namespace Portafolio.Controllers
{
    public class CurriculumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
