namespace BookBeacon.Models.Models;

public class BookCondition : PrimaryKeyBaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Copy> Copies { get; set; } = new List<Copy>();
}
