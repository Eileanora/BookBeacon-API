namespace BookBeacon.BL.ResourceParameters;

public class BookResourceParameters : BaseResourceParameters
{
    public BookResourceParameters()
    {
        OrderBy = "Title";
    }
    
    public string? Title { get; set; }
    public string? ISBN { get; set; }
    public string? Genre { get; set; }
    public string? Language { get; set; }
    public string? Author { get; set; }
    public string? Publisher { get; set; }
    public string? Category { get; set; }
}
