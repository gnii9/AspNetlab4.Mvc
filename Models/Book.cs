namespace AspNetWeek2.Mvc.Models;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }
    public int AvailableCopies { get; set; }

    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
}