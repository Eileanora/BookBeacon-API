using BookBeacon.BL.Services.UserSession;

namespace BookBeacon.BL.Services.CurrentUserService;

public interface ICurrentUserService
{
    IUserSession GetCurrentUser();
}