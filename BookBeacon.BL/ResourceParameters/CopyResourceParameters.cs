namespace BookBeacon.BL.ResourceParameters;

public class CopyResourceParameters : BaseResourceParameters
{
    public CopyResourceParameters()
    {
        OrderBy = "id";
    }
    
    public int BookId { get; set; } = 0;
    public string? IsAvailable { get; set; }
    public string? Condition { get; set; }
    
    public string? Language { get; set; }
}
