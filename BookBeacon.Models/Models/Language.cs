namespace BookBeacon.Models.Models;

public class Language : PrimaryKeyBaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Copy> Copies { get; set; } = new List<Copy>();
}
