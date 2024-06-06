using System.Text.Json.Serialization;

namespace BookBeacon.BL.DTOs.CopyDTOs;

public class CopyDto
{
    public int? Id { get; set; }
    public bool? IsAvailable { get; set; }
    public string? Location { get; set; }
    public string? Notes { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? BookId { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ConditionId { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ConditionName { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? LanguageId { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LanguageName { get; set; }
}
