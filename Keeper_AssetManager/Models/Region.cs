using System.ComponentModel.DataAnnotations;

namespace Keeper_AssetManager.Models;

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