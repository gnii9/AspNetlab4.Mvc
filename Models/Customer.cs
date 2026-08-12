namespace AspNetWeek2.Mvc.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        // 🔗 1 Customer - nhiều Sales
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}