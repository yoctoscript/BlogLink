using BlogLink.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace BlogLink.Services;

public class JwtService
{
    private const int ExpiryDuration = 1;
    private readonly IConfiguration configuration;
    private readonly UserManager<IdentityUser> userManager;
    public JwtService(IConfiguration configuration, UserManager<IdentityUser> userManager)
    {
        this.configuration = configuration;
        this.userManager = userManager;
    }

    public AuthResponse CreateToken(IdentityUser identityUser)
    {
        var expiration = DateTime.UtcNow.AddMonths(ExpiryDuration);

        var token = CreateJwtToken(CreateClaims(identityUser), CreateSigningCredentials(), expiration);
    
        var tokenHandler = new JwtSecurityTokenHandler();

        return new AuthResponse {Token = tokenHandler.WriteToken(token), Expiration = expiration};
    }

    private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) =>
        new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);
    
    private Claim[] CreateClaims(IdentityUser identityUser) =>
        new[]{
            new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.NameIdentifier, identityUser.Id),
            new Claim(ClaimTypes.Name, identityUser.UserName)
        };

    private SigningCredentials CreateSigningCredentials() =>
        new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
            SecurityAlgorithms.HmacSha256
        );
}