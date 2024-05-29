namespace BookBeacon.Models.Models;

public class BookGenres : BaseEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; } = new();
    
    public int GenreId { get; set; }
    public Genre Genre { get; set; } = new();
}
