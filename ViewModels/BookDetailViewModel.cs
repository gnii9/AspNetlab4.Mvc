namespace AspNetWeek2.Mvc.ViewModels
{
    public class BookDetailViewModel
    {
        public int Id { get; set; }

        public string Sku { get; set; } = "";
        public string Name { get; set; } = "";
        public string Genre { get; set; } = "";
        public string Supplier { get; set; } = "";

        public decimal Price { get; set; }

        public string PriceText
            => Price.ToString("N0") + " VNĐ";

        public int Quantity { get; set; }

        public int MinAvailableCopies { get; set; }

        public decimal InventoryValue
            => Price * Quantity;

        public string InventoryValueText
            => InventoryValue.ToString("N0") + " VNĐ";

        public string AvailableCopiesStatus =>
            Quantity <= 0 ? "Out Of AvailableCopies"
            : Quantity <= MinAvailableCopies ? "Need ReSale"
            : "In AvailableCopies";

        public string ReSaleSuggestion =>
            Quantity <= MinAvailableCopies
                ? "ReSale now"
                : "AvailableCopies is sufficient";

        public DateTime LastUpdated { get; set; }

        public string LastUpdatedText =>
            LastUpdated.ToString("dd/MM/yyyy HH:mm");
    }
}