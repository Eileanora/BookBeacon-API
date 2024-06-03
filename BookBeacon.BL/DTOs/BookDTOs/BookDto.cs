using System.Text.Json.Serialization;
using BookBeacon.BL.DTOs.GenreDTOs;

namespace BookBeacon.BL.DTOs.BookDTOs;

public class BookDto
{
    public int? Id { get; set; }
    public string? Title { get; set; } = string.Empty;
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Edition { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? PublicationDate { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ISBN { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Summary { get; set; } = string.Empty;
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PageCount { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PublisherId { get; set; }
    public string? Publisher { get; set; } 
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CategoryId { get; set; }
    public string? Category { get; set; } 
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? AuthorId { get; set; }
    public string? Author { get; set; } 
    public int? AvailableCopies { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<string>? Languages { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<GenreDto>? Genres { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<string>? GenresNames { get; set; }
}
