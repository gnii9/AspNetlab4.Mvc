namespace AspNetWeek2.Mvc.Services
{
    public interface ISaleService
    {
        Task CreateSaleAsync(int BookId, int quantity);
    }
}