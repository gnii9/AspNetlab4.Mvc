using AspNetWeek2.Mvc.Models;

namespace AspNetWeek2.Mvc.Repositories
{
    public interface ISaleRepository
    {
        Task AddAsync(Sale Sale);
        Task SaveChangesAsync();
    }
}