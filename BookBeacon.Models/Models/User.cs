using Microsoft.AspNetCore.Identity;

namespace BookBeacon.Models.Models;

public class User : IdentityUser 
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? About { get; set; }
    
    public int GenderId { get; set; }
    public Gender? Gender { get; set; }
    
    public int LateReturnCount { get; set; } = 0;
    
    public int? MembershipTypeId { get; set; }
    public MembershipType? MembershipType { get; set; }
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
