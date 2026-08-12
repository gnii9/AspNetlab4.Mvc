namespace AspNetWeek2.Mvc.ViewModels
{
    public class BookListItemViewModel
    {
        public int Id { get; set; }

        public string Sku { get; set; } = "";

        public string Name { get; set; } = "";

        public string Genre { get; set; } = "";

        public string GenreName { get; set; } = "";

        public decimal Price { get; set; }

        public string PriceText => Price.ToString("N0") + " VNĐ";

        public int Quantity { get; set; }

        public int AvailableCopies { get; set; }

        public string AvailableCopiesStatus =>
            AvailableCopies == 0
                ? "Out of AvailableCopies"
                : AvailableCopies < 10
                    ? "Low AvailableCopies"
                    : "In AvailableCopies";
    }
}