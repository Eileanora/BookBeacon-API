namespace BookBeacon.Models.Models;

public class MembershipType : PrimaryKeyBaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    
    public int DurationInMonths { get; set; }
    public int DiscountRate { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
}
