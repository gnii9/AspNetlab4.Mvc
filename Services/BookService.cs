using AspNetWeek2.Mvc.Data;
using AspNetWeek2.Mvc.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AspNetWeek2.Mvc.Services;

public class BookService : IBookService
{
    private readonly AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<BookListItemViewModel>> GetBookListAsync()
    {
        var Books = await _context.Books
            .Include(p => p.Genre)
            .AsNoTracking()
            .ToListAsync();

        return Books.Select(p => new BookListItemViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            AvailableCopies = p.AvailableCopies,
            GenreName = p.Genre != null
                ? p.Genre.Name
                : "N/A"
        }).ToList();
    }

    public async Task<BookListItemViewModel?> GetByIdAsync(int id)
    {
        var p = await _context.Books
            .Include(x => x.Genre)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (p == null)
            return null;

        return new BookListItemViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            AvailableCopies = p.AvailableCopies,
            GenreName = p.Genre != null
                ? p.Genre.Name
                : "N/A"
        };
    }
}