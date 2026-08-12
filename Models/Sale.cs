namespace AspNetWeek2.Mvc.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; }

        // 1 Sale có nhiều SaleItem
        public List<SaleItem> SaleItems { get; set; } = new();
    }
}