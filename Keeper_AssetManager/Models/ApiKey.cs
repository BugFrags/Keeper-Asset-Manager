using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keeper_AssetManager.Models;

public class ApiKey
{
    [Key]
    public int KeyId { get; set; }
    
    [Required]
    public int UserId { get; set; }

    [ForeignKey("UserId")] public User User { get; set; } = null!;
    
    [Required,  MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string KeyHash { get; set; } = string.Empty;
    
    [Required, MaxLength(20)]
    public string Prefix { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;
    public DateTime? ExpiresAt { get; set; }
    public DateTime? LastUsedAt { get; set; }
    public bool IsExpired { get; set; } = false;
}