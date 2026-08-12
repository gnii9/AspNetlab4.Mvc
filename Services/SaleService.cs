using AspNetWeek2.Mvc.Repositories;
using AspNetWeek2.Mvc.Models;

namespace AspNetWeek2.Mvc.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _SaleRepo;
        private readonly IBookRepository _BookRepo;

        public SaleService(ISaleRepository SaleRepo, IBookRepository BookRepo)
        {
            _SaleRepo = SaleRepo;
            _BookRepo = BookRepo;
        }

        public async Task CreateSaleAsync(int BookId, int quantity)
        {
            var Book = await _BookRepo.GetByIdAsync(BookId);

            if (Book == null)
                throw new Exception("Book not found");

            if (Book.AvailableCopies < quantity)
                return;

            Book.AvailableCopies -= quantity;

            var Sale = new Sale
            {
                CreatedAt = DateTime.Now,
                TotalAmount = Book.Price * quantity
            };

            await _SaleRepo.AddAsync(Sale);
            await _SaleRepo.SaveChangesAsync();
        }
    }
}