using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BlogLink.Models;

public class AuthResponse
{
    public string Token {get; set;}
    public DateTime Expiration {get; set;}
}