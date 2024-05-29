namespace BookBeacon.Models.Models;

public class Genre : PrimaryKeyBaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = new List<Book>();
}

