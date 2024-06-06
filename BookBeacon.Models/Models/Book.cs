namespace BookBeacon.Models.Models;

public class Book : PrimaryKeyBaseEntity
{
    public string Title { get; set; } = string.Empty;
    public int Edition { get; set; }
    public DateTime PublicationDate { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public int PageCount { get; set; }
    
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; } 
    
    public int CategoryId { get; set; }
    public Category Category { get; set; } 
    
    public int AuthorId { get; set; }
    public Author Author { get; set; } 
    public ICollection<Copy> Copies { get; set; } = new List<Copy>();
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
}

