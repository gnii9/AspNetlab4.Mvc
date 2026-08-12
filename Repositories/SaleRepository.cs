using AspNetWeek2.Mvc.Data;
using AspNetWeek2.Mvc.Models;

namespace AspNetWeek2.Mvc.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _context;

        public SaleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Sale Sale)
            => await _context.Sales.AddAsync(Sale);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}