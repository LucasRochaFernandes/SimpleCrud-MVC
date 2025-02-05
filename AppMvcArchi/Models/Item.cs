namespace AppMvcArchi.Models;

public class Item
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
}
