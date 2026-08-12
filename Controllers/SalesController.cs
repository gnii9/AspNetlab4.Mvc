using Microsoft.AspNetCore.Mvc;
using AspNetWeek2.Mvc.Services;
using AspNetWeek2.Mvc.ViewModels;

namespace AspNetWeek2.Mvc.Controllers
{
public class SalesController : Controller
{
private readonly ISaleService _SaleService;
private readonly IBookService _BookService;


    public SalesController(
        ISaleService SaleService,
        IBookService BookService)
    {
        _SaleService = SaleService;
        _BookService = BookService;
    }

    // GET: /Sales/Create
    // GET: /Sales/Create?id=1
    [HttpGet]
    public async Task<IActionResult> Create(int? id)
    {
        if (id == null)
            return View(new SaleCreateViewModel());

        var Book = await _BookService.GetByIdAsync(id.Value);

        if (Book == null)
            return NotFound();

        return View(new SaleCreateViewModel
        {
            BookId = Book.Id,
            BookName = Book.Name
        });
    }

    // POST: /Sales/Create
    [HttpPost]
    public async Task<IActionResult> Create(SaleCreateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        try
        {
            await _SaleService.CreateSaleAsync(
                model.BookId,
                model.Quantity);

            TempData["Success"] =
                "Sale created successfully.";

            return RedirectToAction(nameof(Success));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(
                string.Empty,
                ex.Message);

            return View(model);
        }
    }

    // GET: /Sales/Success
    [HttpGet]
    public IActionResult Success()
    {
        return View();
    }
}

}
