namespace BookBeacon.Models.Models;

public class BookLanguage : BaseEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; } 
    
    public int LanguageId { get; set; }
    public Language Language { get; set; } 
}
