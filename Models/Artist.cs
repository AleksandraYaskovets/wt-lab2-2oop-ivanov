namespace wt_lab2_2oop_ivanov.Models;

public class Artist : BaseEntity
{
    public string Name { get; set; } = "";
    public string Country { get; set; } = "";
    public List<Album> Albums { get; set; } = new();

    public Artist() { }

    public Artist(int id, string name, string country)
    {
        Id = id;
        Name = name;
        Country = country;
    }

    public override string GetDisplayName() => Name;

    public override void PrintInfo()
    {
        Console.WriteLine($"[Artist #{Id}] {Name} ({Country}), альбомов: {Albums.Count}");
    }
}