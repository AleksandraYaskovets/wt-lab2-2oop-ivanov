namespace wt_lab2_2oop_ivanov.Models;

public class Album : BaseEntity
{
    public string Title { get; set; } = "";
    public string ArtistName { get; set; } = "";
    public int Year { get; set; }
    public List<Track> Tracks { get; set; } = new();

    public Album() { }

    public Album(int id, string title, string artistName, int year)
    {
        Id = id;
        Title = title;
        ArtistName = artistName;
        Year = year;
    }

    public override string GetDisplayName() => $"{Title} ({Year}) — {ArtistName}";

    public override void PrintInfo()
    {
        Console.WriteLine($"[Album #{Id}] {GetDisplayName()}, треков: {Tracks.Count}");
    }

    public int TotalDuration() => Tracks.Sum(t => t.DurationSeconds);
}