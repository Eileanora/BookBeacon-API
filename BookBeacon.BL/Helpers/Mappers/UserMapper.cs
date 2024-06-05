using BookBeacon.BL.DTOs.UserDTOs;
using BookBeacon.Models.Models;

namespace BookBeacon.BL.Helpers.Mappers;

public static class UserMapper
{
    public static User ToCreateEntity(this UserForRegisterDto userDto) => new User
    {
        FirstName = userDto.FirstName,
        LastName = userDto.LastName,
        UserName = userDto.UserName,
        GenderId = userDto.GenderId, 
        Email = userDto.Email
    };

    public static UserDto ToLoginDto(this User user, IEnumerable<string> roles) => new UserDto
    {
        Id = user.Id,
        Roles = roles,
    };

}
