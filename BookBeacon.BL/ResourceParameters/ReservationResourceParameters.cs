namespace BookBeacon.BL.ResourceParameters;

public class ReservationResourceParameters : BaseResourceParameters
{
    public ReservationResourceParameters()
    {
        OrderBy = "StartDate desc";
    }
    
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public string? IsDue { get; set; }
    public string? BookTitle { get; set; }
    public string? UserId { get; set; }
}