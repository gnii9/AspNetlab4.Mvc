namespace AspNetWeek2.Mvc.ViewModels;

public class SaleCreateViewModel
{
    public int BookId { get; set; }
    public int Quantity { get; set; }

    public string? BookName { get; set; }
}