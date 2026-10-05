namespace wt_lab2_2oop_ivanov.Interfaces;

public interface IEntity
{
    int Id { get; set; }
    DateTime CreatedAt { get; }
    string GetDisplayName();
}