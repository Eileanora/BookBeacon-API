namespace BookBeacon.BL.DTOs.UserDTOs;

public class UserInfoDto
{
    public string? Id { get; set; }  
    public string? UserName { get; set; }  
    public string? FirstName { get; set; }  
    public string? LastName { get; set; }  
    public string? Email { get; set; }  
    public string? Gender { get; set; }  
    public string? About { get; set; }
    public IEnumerable<string>? Roles { get; set; } = new List<string>();
    public int LateReturnCount { get; set; }
}
