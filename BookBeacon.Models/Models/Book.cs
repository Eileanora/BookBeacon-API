namespace BookBeacon.Models.Models;

public class Book : PrimaryKeyBaseEntity
{
    public string Title { get; set; } = string.Empty;
    public int Edition { get; set; }
    public DateTime PublicationDate { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public int PageCount { get; set; }
    
    public int LanguageId { get; set; }
    
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; } = new();
    
    public int CategoryId { get; set; }
    public Category Category { get; set; } = new();
    
    public int AuthorId { get; set; }
    public Author Author { get; set; } = new();
    
    public ICollection<Language> Languages { get; set; } = new List<Language>();
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    public ICollection<Copy> Copies { get; set; } = new List<Copy>();
}

