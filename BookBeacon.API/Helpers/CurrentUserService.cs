using System.Security.Claims;
using BookBeacon.BL.Services.CurrentUserService;
using BookBeacon.BL.Services.UserSession;

namespace BookBeacon.API.Helpers;

public class CurrentUserService(IHttpContextAccessor contextAccessor) : ICurrentUserService
{
    public IUserSession GetCurrentUser()
    {
        if (contextAccessor?.HttpContext == null)
            return new UserSession();
        
        if (contextAccessor.HttpContext.User.Identity is { IsAuthenticated: false })
            return new UserSession();
        
        var currentUser = new UserSession
        {
            IsAuthenticated = contextAccessor.HttpContext.User.Identity != null && contextAccessor.HttpContext.User.Identity.IsAuthenticated,
            
            UserId = contextAccessor.HttpContext.User
                        .FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty,
            
            IsAdmin = contextAccessor.HttpContext.User.IsInRole("Admin"),
        };
        return currentUser;
    }
}
