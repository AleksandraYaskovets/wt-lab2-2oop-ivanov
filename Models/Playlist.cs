namespace wt_lab2_2oop_ivanov.Models;

public class Playlist : BaseEntity
{
    public string Name { get; set; } = "";
    public List<Track> Tracks { get; set; } = new();

    public Playlist() { }

    public Playlist(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string GetDisplayName() => Name;

    public override void PrintInfo()
    {
        Console.WriteLine($"[Playlist #{Id}] {Name}, треков: {Tracks.Count}, общая длительность: {Tracks.Sum(t => t.DurationSeconds) / 60} мин");
    }

    public void AddTrack(Track track) => Tracks.Add(track);
    public void RemoveTrack(int trackId) => Tracks.RemoveAll(t => t.Id == trackId);
}