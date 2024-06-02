using System.Text.Json.Serialization;

namespace BookBeacon.BL.DTOs.AuthorDTOs;

public class AuthorDto
{
    public int? Id { get; set; }
    public string? FullName { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FirstName { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LastName { get; set; }
    public string? Biography { get; set; }
}
