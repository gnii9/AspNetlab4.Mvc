using AspNetWeek2.Mvc.Data;
using AspNetWeek2.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetWeek2.Mvc.Controllers;

public class GenresController : Controller
{
    private readonly AppDbContext _context;

    public GenresController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _context.Genres
            .Include(c => c.Books)
            .Select(c => new GenreViewModel
            {
                Id = c.Id,
                Name = c.Name,
                BookNames = string.Join(", ",
                    c.Books.Select(p => p.Name)),
                Relationship = "1 - Many",
                DbSetName = "Genres"
            })
            .ToListAsync();

        return View(model);
    }
}