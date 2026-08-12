using Microsoft.AspNetCore.Mvc;
using AspNetWeek2.Mvc.Services;

namespace AspNetWeek2.Mvc.Controllers
{
public class BooksController : Controller
{
private readonly IBookService _BookService;

    public BooksController(IBookService BookService)
    {
        _BookService = BookService;
    }

    public async Task<IActionResult> Index()
    {
        var Books = await _BookService.GetBookListAsync();
        return View(Books);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var Book = await _BookService.GetByIdAsync(id);

        if (Book == null)
            return NotFound();

        return View(Book);
    }
}

}
