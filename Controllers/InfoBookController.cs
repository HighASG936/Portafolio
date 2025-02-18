using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Repository;

namespace Portafolio.Controllers
{
    public class InfoBookController(IRepository<Book> Book) : Controller
    {
        private readonly IRepository<Book> _book = Book;

        public async Task<IActionResult> Details(int id) 
        {
            var book = await _book.GetById(id);
            if (book is null)
            {
                return NotFound();
            }
            return View(book);
        }

    }
}