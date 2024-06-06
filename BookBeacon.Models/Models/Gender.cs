namespace BookBeacon.Models.Models;

public class Gender : PrimaryKeyBaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; } = new List<User>();
}
