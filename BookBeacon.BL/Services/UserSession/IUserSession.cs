namespace BookBeacon.BL.Services.UserSession;

public interface IUserSession
{
    string UserId { get; set; }
    bool IsAuthenticated { get; set; }
    bool IsAdmin { get; set; }
}
