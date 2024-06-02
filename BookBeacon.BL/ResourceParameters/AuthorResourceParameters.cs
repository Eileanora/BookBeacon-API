namespace BookBeacon.BL.ResourceParameters;

public class AuthorResourceParameters : BaseResourceParameters
{
    public AuthorResourceParameters()
    {
        OrderBy = "FirstName";
    }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
}
