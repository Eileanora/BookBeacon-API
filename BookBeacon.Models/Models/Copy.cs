namespace BookBeacon.Models.Models;

public class Copy : PrimaryKeyBaseEntity
{
    public bool IsAvailable { get; set; } = true;
    public string? Location { get; set; }
    public string? Notes { get; set; }
    
    public Book? Book { get; set; }
    public int? BookId { get; set; }
    
    public int ConditionId { get; set; }
    
    public Language? Language { get; set; }
    public int LanguageId { get; set; }
    public BookCondition? Condition { get; set; }
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
