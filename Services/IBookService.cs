using AspNetWeek2.Mvc.ViewModels;

namespace AspNetWeek2.Mvc.Services;

public interface IBookService
{
    Task<List<BookListItemViewModel>> GetBookListAsync();
    Task<BookListItemViewModel?> GetByIdAsync(int id);
}