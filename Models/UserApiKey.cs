using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace BlogLink.Models;

public class UserApiKey
{
    [Key]
    [JsonIgnore]
    public int Id {get; set;}
    [Required]
    public string Value {get; set;}
    [JsonIgnore]
    public string IdentityUserId {get; set;}
}