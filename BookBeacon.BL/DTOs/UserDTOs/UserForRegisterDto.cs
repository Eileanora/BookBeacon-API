using System.Text.Json.Serialization;

namespace BookBeacon.BL.DTOs.UserDTOs;

public class UserForRegisterDto
{
    public string UserName { get; set; }  
    public string FirstName { get; set; }  
    public string LastName { get; set; }  
    public string Email { get; set; }  
    public int GenderId { get; set; }
    public string Password { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? About { get; set; }
}
