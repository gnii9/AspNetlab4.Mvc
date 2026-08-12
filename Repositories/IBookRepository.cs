using AspNetWeek2.Mvc.Models;

namespace AspNetWeek2.Mvc.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
}