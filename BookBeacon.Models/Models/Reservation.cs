namespace BookBeacon.Models.Models;

public class Reservation : PrimaryKeyBaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsReturned { get; set; }
    public string? Notes { get; set; }
    
    public int CopyId { get; set; }
    public Copy? Copy { get; set; }
    public string UserId { get; set; }
    public User? User { get; set; }
}
