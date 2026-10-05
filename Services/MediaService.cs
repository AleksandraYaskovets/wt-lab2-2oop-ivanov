using wt_lab2_2oop_ivanov.Models;

namespace wt_lab2_2oop_ivanov.Services;

public class MediaService
{
    private readonly List<Track> _tracks = new();
    private readonly List<Album> _albums = new();
    private readonly List<Artist> _artists = new();
    private readonly List<Playlist> _playlists = new();
    private readonly Dictionary<int, Track> _trackById = new();
    private int _nextId = 1;

    public Track AddTrack(string title, string artist, int seconds, string genre)
    {
        var track = new Track(_nextId++, title, artist, seconds, genre);
        _tracks.Add(track);
        _trackById[track.Id] = track;
        return track;
    }

    public Album AddAlbum(string title, string artist, int year)
    {
        var album = new Album(_nextId++, title, artist, year);
        _albums.Add(album);
        return album;
    }

    public Artist AddArtist(string name, string country)
    {
        var artist = new Artist(_nextId++, name, country);
        _artists.Add(artist);
        return artist;
    }

    public Playlist AddPlaylist(string name)
    {
        var playlist = new Playlist(_nextId++, name);
        _playlists.Add(playlist);
        return playlist;
    }

    public Task SeedAsync()
    {
        if (_tracks.Count > 0) return Task.CompletedTask;

        var queen = AddArtist("Queen", "UK");
        var lennon = AddArtist("John Lennon", "UK");

        var opera = AddAlbum("A Night at the Opera", "Queen", 1975);
        var imagine = AddAlbum("Imagine", "John Lennon", 1971);

        var t1 = AddTrack("Bohemian Rhapsody", "Queen", 355, "Rock");
        var t2 = AddTrack("Love of My Life", "Queen", 219, "Rock");
        var t3 = AddTrack("Imagine", "John Lennon", 183, "Pop");
        var t4 = AddTrack("Jealous Guy", "John Lennon", 254, "Pop");
        var t5 = AddTrack("Don't Stop Me Now", "Queen", 209, "Rock");

        opera.Tracks.AddRange(new[] { t1, t2, t5 });
        imagine.Tracks.AddRange(new[] { t3, t4 });
        queen.Albums.Add(opera);
        lennon.Albums.Add(imagine);

        var playlist = AddPlaylist("Лучшее");
        playlist.AddTrack(t1);
        playlist.AddTrack(t3);
        playlist.AddTrack(t5);

        return Task.CompletedTask;
    }

    public void PrintTracks()
    {
        Console.WriteLine("\n--- Все треки ---");
        if (_tracks.Count == 0) { Console.WriteLine("Список пуст"); return; }
        foreach (var t in _tracks) t.PrintInfo();
    }

    public void PrintAlbums()
    {
        Console.WriteLine("\n--- Все альбомы ---");
        if (_albums.Count == 0) { Console.WriteLine("Список пуст"); return; }
        foreach (var a in _albums) a.PrintInfo();
    }

    public void PrintArtists()
    {
        Console.WriteLine("\n--- Все артисты ---");
        if (_artists.Count == 0) { Console.WriteLine("Список пуст"); return; }
        foreach (var a in _artists) a.PrintInfo();
    }

    public void PrintPlaylists()
    {
        Console.WriteLine("\n--- Все плейлисты ---");
        if (_playlists.Count == 0) { Console.WriteLine("Список пуст"); return; }
        foreach (var p in _playlists) p.PrintInfo();
    }

    public Track? FindTrack(int id) => _tracks.FirstOrDefault(t => t.Id == id);

    public void PrintTrackById(int id)
    {
        var track = FindTrack(id);
        if (track == null)
            Console.WriteLine($"Трек с Id={id} не найден");
        else
            track.PrintInfo();
    }

    public void PrintStatistics()
    {
        Console.WriteLine("\n--- Статистика ---");
        Console.WriteLine($"Всего треков: {_tracks.Count}");
        Console.WriteLine($"Общая длительность: {_tracks.Sum(t => t.DurationSeconds) / 60} мин");
        Console.WriteLine($"Средняя: {_tracks.Average(t => t.DurationSeconds):F0} сек");
        Console.WriteLine($"Мин: {_tracks.Min(t => t.DurationSeconds)} сек");
        Console.WriteLine($"Макс: {_tracks.Max(t => t.DurationSeconds)} сек");

        Console.WriteLine("\n--- Группировка по жанрам ---");
        var byGenre = _tracks.GroupBy(t => t.Genre)
            .Select(g => new { Genre = g.Key, Count = g.Count(), Total = g.Sum(t => t.DurationSeconds) / 60 });
        foreach (var g in byGenre)
            Console.WriteLine($"{g.Genre}: {g.Count} треков, {g.Total} мин");
    }
}