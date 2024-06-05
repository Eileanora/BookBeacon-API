namespace BookBeacon.BL.Services.UserSession;

public class UserSession : IUserSession
{
    public string UserId { get; set; }
    public bool IsAuthenticated { get; set; }
    public bool IsAdmin { get; set; }
}
