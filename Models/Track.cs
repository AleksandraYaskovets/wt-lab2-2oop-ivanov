namespace wt_lab2_2oop_ivanov.Models;

public class Track : BaseEntity
{
    public string Title { get; set; } = "";
    public string ArtistName { get; set; } = "";
    public string Genre { get; set; } = "";

    private int _durationSeconds;
    public int DurationSeconds
    {
        get => _durationSeconds;
        private set
        {
            if (value <= 0)
                throw new ArgumentException("Длительность должна быть положительной");
            _durationSeconds = value;
        }
    }

    public Track() { }

    public Track(int id, string title, string artistName, int durationSeconds, string genre)
    {
        Id = id;
        Title = title;
        ArtistName = artistName;
        DurationSeconds = durationSeconds;
        Genre = genre;
    }

    public override string GetDisplayName() => $"{Title} — {ArtistName}";

    public override void PrintInfo()
    {
        Console.WriteLine($"[Track #{Id}] {GetDisplayName()} ({DurationSeconds / 60}:{DurationSeconds % 60:D2}) [{Genre}]");
    }

    public void UpdateDuration(int seconds)
    {
        if (seconds <= 0)
            throw new ArgumentException("Длительность должна быть положительной");
        DurationSeconds = seconds;
    }
}