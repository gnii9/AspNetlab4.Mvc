namespace AspNetWeek2.Mvc.Models
{
    public class SaleItem
    {
        public int Id { get; set; }

        // 🔗 FK tới Sale
        public int SaleId { get; set; }
        public Sale? Sale { get; set; }

        // 🔗 FK tới Book
        public int BookId { get; set; }
        public Book? Book { get; set; }

        // 📊 dữ liệu nghiệp vụ
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // 👉 helper (không bắt buộc nhưng hay dùng)
        public decimal Total => Quantity * UnitPrice;
    }
}