using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Repository;
using System.IO;

namespace Portafolio.Controllers
{
    public class BooksController(IRepository<Book> _book) : Controller
    {
        public async Task<IActionResult> Index() =>
            View(await _book.Get());

        public void asdf() 
        {
            Path.Combine();
        }

    }
}