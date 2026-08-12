using AspNetWeek2.Mvc.Data;
using AspNetWeek2.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetWeek2.Mvc.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Book>> GetAllAsync()
    {
        return _context.Books
            .Include(p => p.Genre)
            .ToListAsync();
    }

    public Task<Book?> GetByIdAsync(int id)
    {
        return _context.Books
            .Include(p => p.Genre)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}