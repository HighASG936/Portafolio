using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Repository;

namespace Portafolio.Controllers
{
    public class DevicesController(IRepository<Device> _device) : Controller
    {
        public async Task<IActionResult> Index() =>
            View(await _device.Get());
    }

}