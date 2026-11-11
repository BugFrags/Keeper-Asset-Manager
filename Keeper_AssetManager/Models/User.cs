using System.ComponentModel.DataAnnotations;

namespace Keeper_AssetManager.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Role { get; set; } = "Viewer";

    public ICollection<Asset> OwnedAssets { get; set; } = new List<Asset>();
    public ICollection<ApiKey> ApiKeys { get; set; } = new List<ApiKey>();
    public ICollection<AuditTrail> AuditLogs { get; set; } = new List<AuditTrail>();
}