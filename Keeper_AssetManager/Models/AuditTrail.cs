using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keeper_AssetManager.Models;

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