namespace AspNetWeek2.Mvc.ViewModels
{
    public class BookStatsViewModel
    {
        public int TotalBooks { get; set; }

        public int TotalQuantity { get; set; }

        public int OutOfAvailableCopiesCount { get; set; }

        public int NeedReSaleCount { get; set; }

        public string TotalInventoryValueText { get; set; } = "";
    }
}