namespace AspNetWeek2.Mvc.ViewModels
{
    public class DataHealthItemViewModel
    {
        public string Check { get; set; } = "";
        public string Expected { get; set; } = "";
        public string Actual { get; set; } = "";
        public string Status { get; set; } = "";
        public string Note { get; set; } = "";
    }
}