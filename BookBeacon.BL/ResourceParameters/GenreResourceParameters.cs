namespace BookBeacon.BL.ResourceParameters;

public class GenreResourceParameters : BaseResourceParameters
{
    public GenreResourceParameters()
    {
        OrderBy = "Name";
    }
    public string? Name { get; set; }
}
