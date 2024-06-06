using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookBeacon.BL.DTOs.UserDTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookBeacon.BL.Managers.JwtTokenManager;

public class JwtTokenManager : IJwtTokenManager
{
    private readonly IConfiguration _configuration;
    
    public JwtTokenManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateAccessToken(UserDto userDto)
    {
        var key = _configuration.GetValue<string>("Jwt:Key");
        var expires = _configuration.GetValue<int>("Jwt:ExpireDays");
        var audience = _configuration.GetValue<string>("Jwt:Audience");
        var issuer = _configuration.GetValue<string>("Jwt:Issuer");
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userDto.Id)
        };

        foreach (var role in userDto.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(expires),
            Audience = audience,
            Issuer = issuer,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

}
