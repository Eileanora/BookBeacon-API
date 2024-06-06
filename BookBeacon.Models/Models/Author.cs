namespace BookBeacon.Models.Models;

public class Author : PrimaryKeyBaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Biography { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
