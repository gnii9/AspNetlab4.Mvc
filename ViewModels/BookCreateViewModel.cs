namespace AspNetWeek2.Mvc.ViewModels
{
    public class BookCreateViewModel
    {
        public string Name { get; set; } = "";

        public string Genre { get; set; } = "";

        public string Supplier { get; set; } = "";

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int MinAvailableCopies { get; set; }
    }
}