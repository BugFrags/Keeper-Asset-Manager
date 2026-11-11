using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keeper_AssetManager.Models;

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
    [ForeignKey("RegionId")] public Models.Region Region { get; set; } = null;
        
    [Required]
    public int OwnerId { get; set; }
    [ForeignKey("OwnerId")] public User Owner { get; set; } = null;
}