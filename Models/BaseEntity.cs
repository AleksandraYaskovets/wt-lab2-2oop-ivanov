using wt_lab2_2oop_ivanov.Interfaces;

namespace wt_lab2_2oop_ivanov.Models;

public abstract class BaseEntity : IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; } = DateTime.Now;

    public abstract string GetDisplayName();

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Entity #{Id}, created {CreatedAt:yyyy-MM-dd}");
    }
}