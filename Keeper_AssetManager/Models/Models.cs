using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keeper_AssetManager.Models;

public class Models
{
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
    
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
    
        [Required, MaxLength(100)]
        public string Name { get; set; } =  string.Empty;
    
        [MaxLength(50)]
        public string Code { get; set; } =  string.Empty;

        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
    
    public class AuditTrail
    {
        [Key]
        public int AuditId { get; set; }
    
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    
        [Required,  StringLength(100)]
        public string Action { get; set; } = string.Empty;
    
        [Required,  StringLength(100)]
        public string TargetEntity { get; set; } = string.Empty;
    
        public int TargetEntityId { get; set; }
    
        public DateTime TimeStamp { get; set; } =  DateTime.UtcNow;
    
        public string? Details { get; set; }
    }
    
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
    
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required, MaxLength(50)]
        public string Category { get; set; } = string.Empty;
        
        [Required, MaxLength(50)]
        public string Type { get; set; } = string.Empty;
        
        public bool Status { get; set; } = true;
        
        [Required]
        public int RegionId { get; set; }
        [ForeignKey("RegionId")] public Region Region { get; set; } = null;
        
        [Required]
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")] public User Owner { get; set; } = null;
    }
}