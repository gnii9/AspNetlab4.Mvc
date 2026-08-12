namespace AspNetWeek2.Mvc.ViewModels;

public class GenreViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string BookNames { get; set; } = "";

    public string Relationship { get; set; } = "1 - Many";

    public string DbSetName { get; set; } = "Genres";
}