using wt_lab2_2oop_ivanov.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("===========================================");
Console.WriteLine("   Медиатека: музыкальный стриминг");
Console.WriteLine("   Вариант 13. Track, Album, Artist, Playlist");
Console.WriteLine("===========================================");
Console.WriteLine();

var service = new MediaService();
await service.SeedAsync();

while (true)
{
    Console.WriteLine("\n--- Меню ---");
    Console.WriteLine("1. Показать все треки");
    Console.WriteLine("2. Показать все альбомы");
    Console.WriteLine("3. Показать всех артистов");
    Console.WriteLine("4. Показать все плейлисты");
    Console.WriteLine("5. Найти трек по Id");
    Console.WriteLine("6. Показать статистику");
    Console.WriteLine("0. Выход");
    Console.Write("Выберите операцию: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1": service.PrintTracks(); break;
        case "2": service.PrintAlbums(); break;
        case "3": service.PrintArtists(); break;
        case "4": service.PrintPlaylists(); break;
        case "5":
            Console.Write("Введите Id трека: ");
            if (int.TryParse(Console.ReadLine(), out var id))
                service.PrintTrackById(id);
            else
                Console.WriteLine("Некорректный Id");
            break;
        case "6": service.PrintStatistics(); break;
        case "0":
            Console.WriteLine("Выход...");
            return;
        default:
            Console.WriteLine("Неизвестная команда");
            break;
    }
}