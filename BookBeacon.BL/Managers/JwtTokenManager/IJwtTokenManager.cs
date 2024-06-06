using BookBeacon.BL.DTOs.UserDTOs;

namespace BookBeacon.BL.Managers.JwtTokenManager;

public interface IJwtTokenManager
{
    string  GenerateAccessToken(UserDto userDto);
}
