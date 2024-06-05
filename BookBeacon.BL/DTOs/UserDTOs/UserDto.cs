namespace BookBeacon.BL.DTOs.UserDTOs;

public class UserDto
{
    public string Id { get; set; }
    public IEnumerable<string> Roles { get; set; } = new List<string>();
    public string? Token { get; set; }
}
